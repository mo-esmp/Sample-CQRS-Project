using MediatR;
using Sample.Core.MovieApplication.Models;
using Sample.Core.MovieApplication.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Queries.GetMovieByName
{
    public class GetMovieByNameQueryHandler : IRequestHandler<GetMovieByNameQuery, MovieReadModel>
    {
        private readonly IMovieReadRepository _repository;

        public GetMovieByNameQueryHandler(IMovieReadRepository repository)
        {
            _repository = repository;
        }

        public Task<MovieReadModel> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByNameAsync(request.MovieName, cancellationToken);
        }
    }
}