using System;

namespace Sample.Core.MovieApplication.Models
{
    public class MovieWriteModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public double ImdbRate { get; set; }

        public decimal BoxOffice { get; set; }

        public int DirectorId { get; set; }

        public DirectorWriteModel Director { get; set; }
    }
}