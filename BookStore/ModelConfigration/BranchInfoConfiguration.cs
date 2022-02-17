using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ModelConfigration
{
    public class BranchInfoConfiguration : EntityTypeConfiguration<BranchInfo>
    {
        public BranchInfoConfiguration()
        {

            this.ToTable("Branches");

            this.HasKey(p => p.ID);

            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
