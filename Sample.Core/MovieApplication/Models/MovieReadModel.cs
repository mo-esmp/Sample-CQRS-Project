using System;

namespace Sample.Core.MovieApplication.Models
{
    public class MovieReadModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int MovieId { get; set; }

        public DateTime PublishDate { get; set; }

        public double ImdbRate { get; set; }

        public decimal BoxOffice { get; set; }

        public string Director { get; set; }
    }
}