using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Core.Common.BaseChannel;
using Sample.Core.MovieApplication.BackgroundWorker.Common.Events;
using Sample.Core.MovieApplication.Models;
using Sample.Core.MovieApplication.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.BackgroundWorker.AddReadMovie
{
    public class AddReadModelWorker : BackgroundService
    {
        private readonly ChannelQueue<MovieAdded> _readModelChannel;
        private readonly ILogger<AddReadModelWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadModelWorker(
            ChannelQueue<MovieAdded> readModelChannel,
            ILogger<AddReadModelWorker> logger,
            IServiceProvider serviceProvider
            )
        {
            _readModelChannel = readModelChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var writeRepository = scope.ServiceProvider.GetRequiredService<IMovieWriteRepository>();
                var readMovieRepository = scope.ServiceProvider.GetRequiredService<IMovieReadRepository>();

                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var movie = await writeRepository.GetByIdAsync(item.MovieId, stoppingToken);

                        if (movie != null)
                            await readMovieRepository.AddAsync(new MovieReadModel
                            {
                                MovieId = movie.Id,
                                Director = movie.Director.FullName,
                                Name = movie.Name,
                                PublishDate = movie.PublishDate,
                                BoxOffice = movie.BoxOffice,
                                ImdbRate = movie.ImdbRate
                            }, stoppingToken);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}