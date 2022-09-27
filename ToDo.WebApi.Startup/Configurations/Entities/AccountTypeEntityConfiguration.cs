using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Enums;

namespace ToDo.WebApi.Startup.Configurations.Entities
{
    public class AccountTypeEntityConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.Property(e => e.Id).HasConversion<int>();
            var values = Enum.GetValues(typeof(AccountTypes))
                .Cast<AccountTypes>()
                .Select(e => new AccountType()
                {
                    Id = e,
                    Name = e.ToString()
                });
            Console.WriteLine(values);
            builder.HasData(values);
        }
    }
}
