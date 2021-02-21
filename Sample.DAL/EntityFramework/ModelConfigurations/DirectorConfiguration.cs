using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.MovieApplication.Models;

namespace Sample.DAL.EntityFramework.ModelConfigurations
{
    internal class DirectorConfiguration : IEntityTypeConfiguration<DirectorWriteModel>
    {
        public void Configure(EntityTypeBuilder<DirectorWriteModel> builder)
        {
            builder.Property(p => p.FullName).IsUnicode().HasMaxLength(256).IsRequired();

            builder.HasMany(d => d.Movies).WithOne(m => m.Director).HasForeignKey(m => m.DirectorId);
        }
    }
}