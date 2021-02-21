using Microsoft.EntityFrameworkCore;
using Sample.Core.MovieApplication.Models;
using Sample.Core.MovieApplication.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.DAL.EntityFramework.WriteRepositories
{
    public class MovieWriteRepository : IMovieWriteRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieWriteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(MovieWriteModel movie, CancellationToken cancellationToken = default)
        {
            await _db.Movies.AddAsync(movie, cancellationToken);
        }

        public Task DeleteAsync(MovieWriteModel movie)
        {
            _db.Movies.Remove(movie);

            return Task.CompletedTask;
        }

        public Task<MovieWriteModel> GetByIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return _db.Movies.Include(c => c.Director).FirstOrDefaultAsync(c => c.Id == movieId, cancellationToken);
        }
    }
}