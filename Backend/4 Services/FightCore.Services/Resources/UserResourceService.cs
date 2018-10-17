using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.Resources;
using FightCore.Services.Patterns;

namespace FightCore.Services.Resources
{
    public interface IUserResourceService : IEntityService<UserResource>
    {

    }
    public class UserResourceService : EntityService<UserResource>, IUserResourceService
    {
        public UserResourceService(IUserResourceRepository repository) : base(repository)
        {
        }
    }
}
