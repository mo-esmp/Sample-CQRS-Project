﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.Core.MovieApplication.BackgroundWorker.Common.Channels;
using Sample.DAL.Model.ReadModels;

namespace Sample.Core.MovieApplication.Notifications.AddReadMovieNotification
{
   public class AddReadModelNotificationHandler:INotificationHandler<AddReadModelNotification>
   {
       private readonly ReadModelChannel _readModelChannel;

       public AddReadModelNotificationHandler(ReadModelChannel readModelChannel)
       {
           _readModelChannel = readModelChannel;
       }

        public async Task Handle(AddReadModelNotification notification, CancellationToken cancellationToken)
        {
            await _readModelChannel.AddToChannelAsync(new Movie
            {
                Name = notification.MovieName,
                BoxOffice = notification.BoxOffice,
                ImdbRate = notification.ImdbRate,
                PublishYear = notification.PublishYear,
                Director = notification.Director,
                MovieId = notification.MovieId
            }, cancellationToken);
        }
    }
}