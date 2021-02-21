using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Core.Common.BaseChannel;
using Sample.Core.MovieApplication.BackgroundWorker.AddReadMovie;
using Sample.Core.MovieApplication.BackgroundWorker.Common.Events;
using Sample.Core.MovieApplication.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.BackgroundWorker.DeleteReadMovie
{
    public class DeleteReadMovieWorker : BackgroundService
    {
        private readonly ChannelQueue<MovieDeleted> _deleteModelChannel;
        private readonly ILogger<AddReadModelWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public DeleteReadMovieWorker(
            ChannelQueue<MovieDeleted> deleteModelChannel,
            ILogger<AddReadModelWorker> logger,
            IServiceProvider serviceProvider)
        {
            _deleteModelChannel = deleteModelChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();

                    var readMovieRepository = scope.ServiceProvider.GetRequiredService<IMovieReadRepository>();

                    await foreach (var item in _deleteModelChannel.ReturnValue(stoppingToken))
                        await readMovieRepository.DeleteByIdAsync(item.MovieId, stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}