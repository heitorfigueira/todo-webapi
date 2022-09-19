using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Infrastructure.Configurations.Entities
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(acc => acc.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(acc => acc.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(acc => acc.CreatedBy)
                .HasConversion<Guid>();

            builder
                .Property(acc => acc.UpdatedBy)
                .HasConversion<Guid>();
        }
    }
}