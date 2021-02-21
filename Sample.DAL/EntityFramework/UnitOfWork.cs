using Sample.Core.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return _db.SaveChangesAsync(cancellationToken);
        }
    }
}