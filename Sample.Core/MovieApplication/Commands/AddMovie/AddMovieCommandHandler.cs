﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.DAL.Model.WriteModels;
using Sample.DAL.WriteRepositories;

namespace Sample.Core.MovieApplication.Commands.AddMovie
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, AddMovieCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly WriteMovieRepository _movieRepository;
        private readonly DirectorRepository _directorRepository;

        public AddMovieCommandHandler(IMediator mediator, WriteMovieRepository movieRepository, DirectorRepository directorRepository)
        {
            _mediator = mediator;
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
        }

        public async Task<AddMovieCommandResult> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var director = await _directorRepository.GetDirectorAsync(request.Director, cancellationToken);

            if (director is null)
            {
                director = new Director { FullName = request.Director };
                await _directorRepository.AddDirectorAsync(director, cancellationToken);
            }

            var movie = new Movie
            {
                PublishYear = request.PublishYear,
                BoxOffice = request.BoxOffice,
                ImdbRate = request.ImdbRate,
                Name = request.Name,
                Director = director
            };

            await _movieRepository.AddMovieAsync(movie, cancellationToken);

            return new AddMovieCommandResult { MovieId = movie.Id };
        }
    }
}