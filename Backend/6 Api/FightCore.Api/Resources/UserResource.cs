using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources
{
    public class UserResource
    {
		/// <summary>
		/// The user name the user is referred by.
		/// </summary>
        public string UserName { get; set; }
    }

    public class UserResultResource : UserResource
    {
        public int Id { get; set; }

		/// <summary>
		/// The email of the user.
		/// </summary>
		public string Email { get; set; }

	}

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
