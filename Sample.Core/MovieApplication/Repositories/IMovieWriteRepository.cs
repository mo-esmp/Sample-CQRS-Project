using Sample.Core.MovieApplication.Models;
using Sample.DAL.Model.WriteModels;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Repositories
{
    public interface IMovieWriteRepository
    {
        Task AddAsync(MovieWriteModel movie, CancellationToken cancellationToken = default);

        Task DeleteAsync(Movie movie);

        Task<Movie> GetByIdAsync(int movieId, CancellationToken cancellationToken = default);
    }
}