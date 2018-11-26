﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FightCore.Api.Resources.Characters;
using FightCore.Api.Resources.Games;

namespace FightCore.Api.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }

    /// <summary>
    /// Only to be used to display the logged in user's details
    /// </summary>
    public class UserResultResource : UserResource
    {
        public string Email { get; set; }
    }

    public class UserWithMetaDataResource : UserResource
    {
        public string Bio { get; set; }

        public List<CharacterResource> FavoriteCharacters { get; set; }

        public List<GameResource> FavoriteGames { get; set; }
    }

    public class NewUserResource : UserResource
    {
        public string Password { get; set; }
    }
}
