using FightCore.Api.Resources.Characters;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using FightCore.Api.Resources.Posts;

namespace FightCore.Api.Examples
{
    /// <inheritdoc />
    public class CharacterResourceExample : IExamplesProvider<CharacterResource>
    {
        /// <inheritdoc />
        public CharacterResource GetExamples()
        {
            return new CharacterResource()
            {
                Name = "Mario",
                Description = "The all-round all-star, star of the show and great red plumber",
                ImageUrl = "https://i.fightcore.org/ultimate/stock/mario",
                Game = new
                {
                    Name = "Super Smash Bros Ultimate.",
                    Console = "Nintendo Switch"
                },
                Posts = new List<PostResource>()
            };
        }
    }
}
