using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ModelConfigration
{
    public class BookPriceConfiguration : EntityTypeConfiguration<BookPrice>
    {
        public BookPriceConfiguration()
        {

            this.ToTable("Prices");

            this.HasKey(p => p.ID);

            this.Property(p => p.BookID)
                .IsRequired();

            this.Property(p => p.BranchID)
                .IsRequired();

            this.Property(p => p.Price)
                .IsRequired();

            this.Property(p => p.PriceDateTime)
                .IsRequired();
        }
    }
}