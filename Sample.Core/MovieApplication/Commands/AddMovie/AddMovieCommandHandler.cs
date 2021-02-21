using MediatR;
using Sample.Core.Common;
using Sample.Core.Common.BaseChannel;
using Sample.Core.MovieApplication.BackgroundWorker.Common.Events;
using Sample.Core.MovieApplication.Models;
using Sample.Core.MovieApplication.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Commands.AddMovie
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, AddMovieCommandResult>
    {
        private readonly IMovieWriteRepository _movieRepository;
        private readonly IDirectorWriteRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<MovieAdded> _channel;

        public AddMovieCommandHandler(
            IMovieWriteRepository movieRepository,
            IDirectorWriteRepository directorRepository,
            IUnitOfWork unitOfWork,
            ChannelQueue<MovieAdded> channel)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }

        public async Task<AddMovieCommandResult> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var director = await _directorRepository.GetByNameAsync(request.Director, cancellationToken);

            if (director is null)
            {
                director = new DirectorWriteModel { FullName = request.Director };
                await _directorRepository.AddAsync(director, cancellationToken);
            }

            var movie = new MovieWriteModel
            {
                PublishDate = request.PublishYear,
                BoxOffice = request.BoxOffice,
                ImdbRate = request.ImdbRate,
                Name = request.Name,
                Director = director
            };

            await _movieRepository.AddAsync(movie, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            await _channel.AddToChannelAsync(new MovieAdded { MovieId = movie.Id }, cancellationToken);

            return new AddMovieCommandResult { MovieId = movie.Id };
        }
    }
}