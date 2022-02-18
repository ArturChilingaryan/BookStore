using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ModelConfigration
{
    public class StockBalanceConfiguration : EntityTypeConfiguration<StockBalance>
    {
        public StockBalanceConfiguration()
        {

            this.ToTable("Balance");

            this.HasKey(p => p.ID);

            this.Property(p => p.BookID)
                .IsRequired();

            this.Property(p => p.BranchID)
                .IsRequired();

            this.Property(p => p.Quantity)
                .IsRequired();

            this.Property(p => p.TypeOfMovement)
                .IsRequired();

            this.Property(p => p.MovementDate)
                .IsRequired();
        }
    }
}