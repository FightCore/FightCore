using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper.Configuration.Conventions;

using FightCore.Api.Resources.Characters;
using FightCore.Api.Resources.Games;
using FightCore.Api.Resources.Shared;
using FightCore.Models.Characters;
using FightCore.Models.Shared;

namespace FightCore.Api.Resources
{
    public class TechniqueResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public GameResource Game { get; set; }

        public List<MediaResource> Media { get; set; }

        /// <summary>
        /// Gets or sets the user who has written this technique
        /// </summary>
        public UserResource Author { get; set; }
    }

    public class DetailedTechniqueResource : TechniqueResource
    {
        /// <summary>
        /// Gets or sets the user written text about how this technique should be executed.
        /// If a user only uses <see cref="Inputs"/> this can be NULL.
        /// </summary>
        [MapTo(nameof(Technique.ExecuteDescription))]
        public string Execution { get; set; }

        /// <summary>
        /// Gets or sets the inputs required to execute the technique
        /// </summary>
        public List<InputChainResource> Inputs { get; set; }

        /// <summary>
        /// Gets or sets the characters that can perform this technique
        /// </summary>
        public List<CharacterResource> Characters { get; set; }

        /// <summary>
        /// Gets or sets a string description about which characters can perform this technique.
        /// Given by the user.
        /// </summary>
        public string CharactersDescription { get; set; }

        /// <summary>
        /// Gets or sets the description of which stages this tech can be executed on.
        /// This value is given by the user and can be null
        /// </summary>
        [MapTo(nameof(Technique.StagesDescription))]
        public string Stages { get; set; }

        /// <summary>
        /// Gets or sets a detailed description about the technique.
        /// </summary>
        public string DetailedDescription { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the technique being performed.
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// Gets or sets a string describing when the technique should be used.
        /// </summary>
        public string Application { get; set; }
    }
}
