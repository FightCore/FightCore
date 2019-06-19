using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Patterns
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context wanting to be inserted.</param>
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public int SaveChanges() => _context.SaveChanges();

        /// <inheritdoc />
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
