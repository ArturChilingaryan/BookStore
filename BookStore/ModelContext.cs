using BookStore.Model;
using BookStore.ModelConfigration;
using System.Data.Entity;

namespace BookStore
{
    public class ModelContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookStore.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public ModelContext()
            : base("name=BookStoreModel")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AuthorInfoConfiguration());

            modelBuilder.Configurations.Add(new BookGenreConfiguration());

            modelBuilder.Configurations.Add(new BookInfoConfiguration());

            modelBuilder.Configurations.Add(new BookPriceConfiguration());

            modelBuilder.Configurations.Add(new BranchInfoConfiguration());

            modelBuilder.Configurations.Add(new SalesConfiguration());

            modelBuilder.Configurations.Add(new StockBalanceConfiguration());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<AuthorInfo> AuthorInfos { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<BookInfo> BookInfos { get; set; }
        public virtual DbSet<BranchInfo> BranchInfos { get; set; }
        public virtual DbSet<BookPrice> BookPrices { get; set; }
        public virtual DbSet<StockBalance> StockBalances { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

    }

}