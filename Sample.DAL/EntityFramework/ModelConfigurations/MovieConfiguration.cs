using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.MovieApplication.Models;

namespace Sample.DAL.EntityFramework.ModelConfigurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<MovieWriteModel>
    {
        public void Configure(EntityTypeBuilder<MovieWriteModel> builder)
        {
            builder.Property(p => p.Name).IsUnicode().HasMaxLength(256).IsRequired();
            builder.Property(p => p.PublishDate).HasColumnType("datetime");
        }
    }
}