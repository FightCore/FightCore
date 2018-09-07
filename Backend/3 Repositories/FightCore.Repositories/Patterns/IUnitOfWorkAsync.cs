using System.Threading.Tasks;

namespace FightCore.Repositories.Patterns
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
