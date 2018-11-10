using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Posts.Resources;
using FightCore.Api.Resources;
using FightCore.Api.Resources.Posts;
using FightCore.Api.Resources.Notifications;
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

            CreateMap<PostResource, Models.Resources.Post>();
            CreateMap<PostResultResource, Models.Resources.Post>().ReverseMap();
            CreateMap<PostPreviewResource, Models.Resources.Post>();

            CreateMap<NotificationResource, Notification>().ReverseMap();
            CreateMap<NotificationResultResource, Notification>().ReverseMap();
        }
    }
}
