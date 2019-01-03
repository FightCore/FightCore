using System.Threading.Tasks;

namespace FightCore.Repositories.Patterns
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        /// <summary>
        /// Saves the changes made to the context.
        /// </summary>
        /// <returns>An awaitable task containing a value indicating if the save was successful.</returns>
        Task<int> SaveChangesAsync();
    }
}
