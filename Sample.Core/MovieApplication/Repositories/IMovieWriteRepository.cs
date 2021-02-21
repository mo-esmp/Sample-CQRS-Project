using Sample.Core.MovieApplication.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Repositories
{
    public interface IMovieWriteRepository
    {
        Task AddAsync(MovieWriteModel movie, CancellationToken cancellationToken = default);

        Task DeleteAsync(MovieWriteModel movie);

        Task<MovieWriteModel> GetByIdAsync(int movieId, CancellationToken cancellationToken = default);
    }
}