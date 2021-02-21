using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Core.MovieApplication.Commands.AddMovie
{
    public class AddMovieCommand : IRequest<AddMovieCommandResult>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime PublishYear { get; set; }

        [Required]
        public double ImdbRate { get; set; }

        [Required]
        public decimal BoxOffice { get; set; }

        [Required]
        public string Director { get; set; }
    }
}