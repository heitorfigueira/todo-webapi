using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Startup.Configurations.Entities
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(acc => acc.TypeId).HasConversion<int>();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(acc => acc.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(acc => acc.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(acc => acc.User)
            //    .WithOne()
            //    .HasForeignKey<User>(us => us.Id)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(acc => acc.CreatedBy)
                .HasConversion<Guid>();

            builder
                .Property(acc => acc.UpdatedBy)
                .HasConversion<Guid>();
        }
    }
}
