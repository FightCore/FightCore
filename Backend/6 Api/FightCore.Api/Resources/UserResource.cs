using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources
{
    /// <summary>
    /// A class to output towards the API.
    /// </summary>
    public class UserResource
    {
		/// <summary>
		/// The user name the user is referred by.
		/// </summary>
        public string Username { get; set; }
    }

    /// <summary>
    /// Expanded the class of the user resource with personal details.
    /// </summary>
    public class UserResultResource : UserResource
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// The email of the user.
		/// </summary>
		public string Email { get; set; }

	}

    /// <summary>
    /// The resource used to create new users.
    /// </summary>
    public class NewUserResource : UserResource
    {
		/// <summary>
		/// The email of the user.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The password the user is using.
		/// </summary>
		public string Password { get; set; }
    }
}
