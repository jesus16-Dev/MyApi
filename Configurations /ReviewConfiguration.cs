using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApi.Models;

namespace MyApi.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.Comment)
                   .HasMaxLength(500);

            builder.Property(r => r.Rating)
                   .IsRequired();

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Platform)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.PlatformId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
