using MediatR;
using Sample.Core.Common;
using Sample.Core.Common.BaseChannel;
using Sample.Core.MovieApplication.BackgroundWorker.Common.Events;
using Sample.Core.MovieApplication.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IMovieWriteRepository _writeMovieRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<MovieDeleted> _channelQueue;

        public DeleteMovieCommandHandler(
            IMovieWriteRepository writeMovieRepository,
            IUnitOfWork unitOfWork,
            ChannelQueue<MovieDeleted> channelQueue)
        {
            _writeMovieRepository = writeMovieRepository;
            _unitOfWork = unitOfWork;
            _channelQueue = channelQueue;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _writeMovieRepository.GetByIdAsync(request.MovieId, cancellationToken);

            if (movie is null)
                return false;

            await _writeMovieRepository.DeleteAsync(movie);

            await _unitOfWork.CommitAsync(cancellationToken);

            await _channelQueue.AddToChannelAsync(new MovieDeleted { MovieId = request.MovieId }, cancellationToken);

            return true;
        }
    }
}