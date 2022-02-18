using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ModelConfigration
{
    public class BookInfoConfiguration : EntityTypeConfiguration<BookInfo>
    {
        public BookInfoConfiguration()
        {

            this.ToTable("Books");

            this.HasKey(p => p.Id);

            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.GenreId)
                .IsOptional();

            this.Property(p => p.AuthorId)
                .IsRequired();
        }
    }
}