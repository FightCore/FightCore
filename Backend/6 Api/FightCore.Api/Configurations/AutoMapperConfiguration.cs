using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Api.Resources.Characters;
using FightCore.Api.Resources.Games;
using FightCore.Api.Resources.Shared;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;
using FightCore.Repositories;

namespace FightCore.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Character, CharacterResource>();
            CreateMap<Character, DetailedCharacterResource>();
            CreateMap<Technique, TechniqueResource>();
            CreateMap<Move, MoveResource>();
            CreateMap<Combo, ComboResource>();

            CreateMap<Game, GameResource>();

            CreateMap<Media, MediaResource>();
            CreateMap<ControllerInput, ControllerInputResource>();
            CreateMap<InputChain, InputChainResource>();
        }
    }
}
