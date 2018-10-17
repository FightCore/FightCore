﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Models;

namespace FightCore.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserResource, ApplicationUser>().ReverseMap();
            CreateMap<UserResultResource, ApplicationUser>().ReverseMap();
            CreateMap<NewUserResource, ApplicationUser>();
            CreateMap<UserPostResource, Models.Resources.UserResource>();
        }
    }
}
