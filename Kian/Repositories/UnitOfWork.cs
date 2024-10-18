using Kian.Context;
using Kian.Contract.Repositories;

namespace Kian.Repositories
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync();
        }
    }
}
