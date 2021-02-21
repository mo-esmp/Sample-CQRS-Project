using Sample.Core.MovieApplication.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Repositories
{
    public interface IMovieReadRepository
    {
        Task DeleteByIdAsync(int movieId, CancellationToken cancellationToken = default);

        Task<MovieReadModel> GetByIdAsync(int movieId, CancellationToken cancellationToken = default);

        Task<MovieReadModel> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}