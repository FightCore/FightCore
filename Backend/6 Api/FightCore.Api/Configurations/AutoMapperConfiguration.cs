using AutoMapper;
using FightCore.Api.Posts.Resources;
using FightCore.Api.Resources;
using FightCore.Api.Resources.Posts;
using FightCore.Api.Resources.Notifications;
using FightCore.Models;

namespace FightCore.Api.Configurations
{
    /// <inheritdoc/>
    public class AutoMapperConfiguration : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperConfiguration"/> class.
        /// </summary>
        public AutoMapperConfiguration()
        {
            CreateMap<UserResource, ApplicationUser>().ReverseMap();
            CreateMap<UserResultResource, ApplicationUser>().ReverseMap();
            CreateMap<NewUserResource, ApplicationUser>();

            CreateMap<PostResource, Models.Resources.Post>();
            CreateMap<PostResultResource, Models.Resources.Post>().ReverseMap(); // Not sure why ReverseMap was originally used for users
            CreateMap<PostPreviewResource, Models.Resources.Post>();

            CreateMap<NotificationResource, Notification>().ReverseMap();
            CreateMap<NotificationResultResource, Notification>().ReverseMap();
        }
    }
}
