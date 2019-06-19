using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FightCore.Api.Middleware
{
	/// <inheritdoc/>
	public class BCryptPasswordHasher<TUser> : PasswordHasher<TUser> where TUser : class
	{
		/// <summary>
		///  Overrides instance of Microsoft.AspNetCore.Identity.PasswordHasher
		/// </summary>
		/// <param name="optionsAccessor"></param>
		public BCryptPasswordHasher(IOptions<PasswordHasherOptions> optionsAccessor = null)
		{

		}

		/// <summary>
		///  Returns a hashed representation of the supplied password for the specified user.
		/// </summary>
		/// <param name="user"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public override string HashPassword(TUser user, string password)
		{
			return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
		}

		/// <summary>
		/// Returns a Microsoft.AspNetCore.Identity.PasswordVerificationResult indicating the result of a password hash comparison.
		/// </summary>
		/// <param name="user"></param>
		/// <param name="hashedPassword">The hash value for a user's stored password.</param>
		/// <param name="providedPassword"> The password supplied for comparison.</param>
		/// <returns></returns>
		public override PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
		{
			if (hashedPassword == null)
			{
				throw new ArgumentNullException(nameof(hashedPassword));
			}
			if (providedPassword == null)
			{
				throw new ArgumentNullException(nameof(providedPassword));
			}

			if (BCryptHelper.CheckPassword(providedPassword, hashedPassword))
			{
				return PasswordVerificationResult.Success;
			}
			else
			{
				return PasswordVerificationResult.Failed;
			}
		}
	}
}
