using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Common
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}