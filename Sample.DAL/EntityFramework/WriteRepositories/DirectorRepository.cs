using Microsoft.EntityFrameworkCore;
using Sample.Core.MovieApplication.Models;
using Sample.Core.MovieApplication.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.DAL.EntityFramework.WriteRepositories
{
    public class DirectorWriteRepository : IDirectorWriteRepository
    {
        private readonly ApplicationDbContext _db;

        public DirectorWriteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(DirectorWriteModel director, CancellationToken cancellationToken = default)
        {
            await _db.Directors.AddAsync(director, cancellationToken);
        }

        public Task<DirectorWriteModel> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return _db.Directors.FirstOrDefaultAsync(d => d.FullName == name, cancellationToken: cancellationToken);
        }
    }
}