using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FightCore.Models.User
{
    public class UserGame
    {
        public ApplicationUser User { get; set; }

        public int UserId { get; set; }

        public Game Game { get; set; }

        public int GameId { get; set; }

        public UserGame()
        {
        }

        public UserGame(ApplicationUser user, Game game)
        {
            User = user;
            UserId = user.Id;
            Game = game;
            GameId = game.Id;
        }
    }
}
