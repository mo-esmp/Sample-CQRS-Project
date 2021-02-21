using Sample.Core.MovieApplication.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Repositories
{
    public interface IDirectorWriteRepository
    {
        Task AddAsync(DirectorWriteModel director, CancellationToken cancellationToken = default);

        Task<DirectorWriteModel> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}