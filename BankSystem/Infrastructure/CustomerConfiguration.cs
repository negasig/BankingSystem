using BankSystem.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infrastructure
{
    public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Balance)
                       .HasPrecision(18, 2);

            }
        }
    }
