using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using FightCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using OpenIddict.Abstractions;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FightCore.Api.Controllers.V1
{
    /// <inheritdoc />
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class AuthorizationController : Controller
    {
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OpenIddictApplicationManager<OpenIddictApplication> _applicationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationController"/> class.
        /// </summary>
        /// <param name="identityOptions">The identity options.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="applicationManager">The application manager.</param>
        public AuthorizationController(
            IOptions<IdentityOptions> identityOptions,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            OpenIddictApplicationManager<OpenIddictApplication> applicationManager)
        {
            _identityOptions = identityOptions;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationManager = applicationManager;
        }

        /// <summary>
        /// Exchanges the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("~/connect/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange(OpenIdConnectRequest request)
        {
            Debug.Assert(request.IsTokenRequest(),
                "The OpenIddict binder for ASP.NET Core MVC is not registered. " +
                "Make sure services.AddOpenIddict().AddMvcBinders() is correctly called.");

            if (request.IsPasswordGrantType())
            {
                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null)
                {
                    return BadRequest(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant,
                        ErrorDescription = "The username/password couple is invalid."
                    });
                }

                // Validate the username/password parameters and ensure the account is not locked out.
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
                if (!result.Succeeded)
                {
                    return BadRequest(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant,
                        ErrorDescription = "The username/password couple is invalid."
                    });
                }

                // Create a new authentication ticket.
                var ticket = await CreateTicketAsync(request, user);

                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }

            if (request.IsRefreshTokenGrantType())
            {
                // Retrieve the claims principal stored in the refresh token.
                var info = await HttpContext.AuthenticateAsync(OpenIdConnectServerDefaults.AuthenticationScheme);

                // Retrieve the user profile corresponding to the refresh token.
                // Note: if you want to automatically invalidate the refresh token
                // when the user password/roles change, use the following line instead:
                //// var user = _signInManager.ValidateSecurityStampAsync(info.Principal);
                var user = await _userManager.GetUserAsync(info.Principal);
                if (user == null)
                {
                    return BadRequest(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant,
                        ErrorDescription = "The refresh token is no longer valid."
                    });
                }

                // Ensure the user is still allowed to sign in.
                if (!await _signInManager.CanSignInAsync(user))
                {
                    return BadRequest(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant,
                        ErrorDescription = "The user is no longer allowed to sign in."
                    });
                }

                // Create a new authentication ticket, but reuse the properties stored
                // in the refresh token, including the scopes originally granted.
                var ticket = await CreateTicketAsync(request, user, info.Properties);

                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }

            if (!request.IsClientCredentialsGrantType())
            {
                return BadRequest(
                    new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
                        ErrorDescription = "The specified grant type is not supported."
                    });
            }

            {
                // Note: the client credentials are automatically validated by OpenIddict:
                // if client_id or client_secret are invalid, this action won't be invoked.
                var application = await _applicationManager.FindByClientIdAsync(
                                      request.ClientId,
                                      HttpContext.RequestAborted);
                if (application == null)
                {
                    return BadRequest(
                        new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidClient,
                            ErrorDescription = "The client application was not found in the database."
                        });
                }

                // Create a new authentication ticket.
                var ticket = CreateTicket(application);

                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }
        }

    private async Task<AuthenticationTicket> CreateTicketAsync(
        OpenIdConnectRequest request, ApplicationUser user,
        AuthenticationProperties properties = null)
    {
        // Create a new ClaimsPrincipal containing the claims that
        // will be used to create an id_token, a token or a code.
        var principal = await _signInManager.CreateUserPrincipalAsync(user);

        // Create a new authentication ticket holding the user identity.
        var ticket = new AuthenticationTicket(principal, properties,
            OpenIdConnectServerDefaults.AuthenticationScheme);

        if (!request.IsRefreshTokenGrantType())
        {
            // Set the list of scopes granted to the client application.
            // Note: the offline_access scope must be granted
            // to allow OpenIddict to return a refresh token.
            ticket.SetScopes(new[]
            {
                    OpenIdConnectConstants.Scopes.OpenId,
                    OpenIdConnectConstants.Scopes.Email,
                    OpenIdConnectConstants.Scopes.Profile,
                    OpenIdConnectConstants.Scopes.OfflineAccess,
                    OpenIddictConstants.Scopes.Roles
                }.Intersect(request.GetScopes()));
        }

        ticket.SetResources("resource_server");

        // Note: by default, claims are NOT automatically included in the access and identity tokens.
        // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
        // whether they should be included in access tokens, in identity tokens or in both.
        foreach (var claim in ticket.Principal.Claims)
        {
            // Never include the security stamp in the access and identity tokens, as it's a secret value.
            if (claim.Type == _identityOptions.Value.ClaimsIdentity.SecurityStampClaimType)
            {
                continue;
            }

            var destinations = new List<string>
                {
                    OpenIdConnectConstants.Destinations.AccessToken
                };

            // Only add the iterated claim to the id_token if the corresponding scope was granted to the client application.
            // The other claims will only be added to the access_token, which is encrypted when using the default format.
            if ((claim.Type == OpenIdConnectConstants.Claims.Name && ticket.HasScope(OpenIdConnectConstants.Scopes.Profile)) ||
                (claim.Type == OpenIdConnectConstants.Claims.Email && ticket.HasScope(OpenIdConnectConstants.Scopes.Email)) ||
                (claim.Type == OpenIdConnectConstants.Claims.Role && ticket.HasScope(OpenIddictConstants.Claims.Roles)))
            {
                destinations.Add(OpenIdConnectConstants.Destinations.IdentityToken);
            }

            claim.SetDestinations(destinations);
        }

        return ticket;
    }

    /// <summary>
    /// Users the information.
    /// </summary>
    /// <returns></returns>
    [HttpGet("~/connect/userinfo"), Produces("application/json")]
    [Authorize]
    public async Task<IActionResult> UserInfo()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return BadRequest(new OpenIdConnectResponse
            {
                Error = OpenIdConnectConstants.Errors.InvalidGrant,
                ErrorDescription = "The user profile is no longer available."
            });
        }

        var claims = new JObject
        {
            [OpenIdConnectConstants.Claims.Subject] = user.Id,
        };

        const string scope = OpenIdConnectConstants.Claims.Scope;

        if (User.HasClaim(scope, OpenIdConnectConstants.Scopes.OpenId))
        {
            claims[OpenIdConnectConstants.Claims.Username] = user.UserName;
        }

        if (User.HasClaim(scope, OpenIdConnectConstants.Scopes.Email))
        {
            claims[OpenIdConnectConstants.Claims.Email] = user.Email;
            claims[OpenIdConnectConstants.Claims.EmailVerified] = user.EmailConfirmed;
        }

        if (User.HasClaim(scope, OpenIddictConstants.Scopes.Roles))
        {
            var roles = await _userManager.GetRolesAsync(user);
            claims[OpenIddictConstants.Scopes.Roles] = JArray.FromObject(roles);
        }

        return Ok(claims);
    }

    private static AuthenticationTicket CreateTicket(OpenIddictApplication application)
    {
        // Create a new ClaimsIdentity containing the claims that
        // will be used to create an id_token, a token or a code.
        var identity = new ClaimsIdentity(
            OpenIdConnectServerDefaults.AuthenticationScheme,
            OpenIdConnectConstants.Claims.Name,
            OpenIdConnectConstants.Claims.Role);

        // Use the client_id as the subject identifier.
        identity.AddClaim(OpenIdConnectConstants.Claims.Subject, application.ClientId,
            OpenIdConnectConstants.Destinations.AccessToken,
            OpenIdConnectConstants.Destinations.IdentityToken);

        identity.AddClaim(OpenIdConnectConstants.Claims.Name, application.DisplayName,
            OpenIdConnectConstants.Destinations.AccessToken,
            OpenIdConnectConstants.Destinations.IdentityToken);

        // Create a new authentication ticket holding the user identity.
        var ticket = new AuthenticationTicket(
            new ClaimsPrincipal(identity),
            new AuthenticationProperties(),
            OpenIdConnectServerDefaults.AuthenticationScheme);

        ticket.SetResources("resource_server");

        return ticket;
    }
}
}