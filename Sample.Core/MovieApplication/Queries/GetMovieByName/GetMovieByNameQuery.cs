using MediatR;
using Sample.Core.MovieApplication.Models;

namespace Sample.Core.MovieApplication.Queries.GetMovieByName
{
    public class GetMovieByNameQuery : IRequest<MovieReadModel>
    {
        public string MovieName { get; set; }
    }
}