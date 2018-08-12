using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace FightCore_DAL
{
    public interface IUnitOfWork
    {
        GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        GenericRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
