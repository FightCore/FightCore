using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Resources
{
    public interface IUserResourceRepository : IRepositoryAsync<UserResource>
    {

    }
    public class UserResourceRepository : Repository<UserResource>, IUserResourceRepository
    {
        public UserResourceRepository(DbContext context) : base(context)
        {
        }

    }
}
