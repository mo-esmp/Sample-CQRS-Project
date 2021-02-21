using MongoDB.Driver;
using Sample.Core.MovieApplication.Models;
using Sample.Core.MovieApplication.Repositories;
using Sample.DAL.EntityFramework.ModelConfigurations;
using Sample.DAL.Mongo.ReadRepositories.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.DAL.Mongo.ReadRepositories
{
    public class MovieReadRepository : BaseReadRepository<MovieReadModel>, IMovieReadRepository
    {
        public MovieReadRepository(IMongoDatabase db) : base(db)
        {
        }

        static MovieReadRepository()
        {
            new MovieConfiguration();
        }

        public Task DeleteByIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return DeleteAsync(m => m.MovieId == movieId, cancellationToken);
        }

        public Task<MovieReadModel> GetByIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return FirstOrDefaultAsync(movie => movie.MovieId == movieId, cancellationToken);
        }

        public Task<MovieReadModel> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return FirstOrDefaultAsync(movie => movie.Name == name, cancellationToken);
        }
    }
}