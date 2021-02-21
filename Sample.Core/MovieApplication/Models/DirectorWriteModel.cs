using Sample.DAL.Model.WriteModels;
using System.Collections.Generic;

namespace Sample.Core.MovieApplication.Models
{
    public class DirectorWriteModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}