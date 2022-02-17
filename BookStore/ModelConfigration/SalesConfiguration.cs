using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ModelConfigration
{
    public class SalesConfiguration : EntityTypeConfiguration<Sales>
    {
        public SalesConfiguration()
        {

            this.ToTable("Sales");

            this.HasKey(p => p.ID);

            this.Property(p => p.Book.Id)
                .IsRequired();

            this.Property(p => p.Branch.ID)
                .IsRequired();

            this.Property(p => p.Quantity)
                .IsRequired();

            this.Property(p => p.Sum)
                .IsOptional();

            this.Property(p => p.TypeOfMovement)
                .IsRequired();

            this.Property(p => p.MovementDate)
                .IsRequired();
        }
    }
}
