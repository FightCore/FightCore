using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Patterns
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
