using System;

namespace Sample.Core.MovieApplication.Models
{
    internal class MovieWriteModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishYear { get; set; }

        public decimal ImdbRate { get; set; }

        public decimal BoxOffice { get; set; }

        public int DirectorId { get; set; }

        public DirectorWriteModel Director { get; set; }
    }
}