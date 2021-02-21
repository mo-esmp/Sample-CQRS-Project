using Microsoft.EntityFrameworkCore;
using Sample.Core.MovieApplication.Models;

namespace Sample.DAL.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<MovieWriteModel> Movies { get; set; }

        public DbSet<DirectorWriteModel> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}