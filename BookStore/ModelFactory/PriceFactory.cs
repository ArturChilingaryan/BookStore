using BookStore.Model;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.ModelFactory
{
    public class PriceFactory
    {
        private static PriceFactory instance;
        private PriceFactory()
        {
        }

        public static PriceFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new PriceFactory();
            }
            return instance;
        }

        public void SetPrice(ModelContext dbcontext, int bookID, int branchID, double price)
        {

            BookInfo book = BookFactory.GetInstance().GetBookByID(dbcontext, bookID);
            BranchInfo branch = BranchFactory.GetInstance().GetBranchInfoByID(dbcontext, branchID);

            BookPrice bookPrice = new BookPrice
            {
                Book = book,
                Branch = branch,
                Price = price,
                PriceDateTime = System.DateTime.Now,
            };

            dbcontext.BookPrices.Add(bookPrice);
            dbcontext.SaveChanges();
        }

        public List<BookPrice> GetPrice(ModelContext dbcontext, int bookID, int branchID)
        {

            var list = dbcontext.BookPrices
                .Where(x => ((x.BranchID == branchID || branchID ==0) && (x.BookID == bookID || bookID ==0)))
                .GroupBy(x => new { x.BranchID, x.BookID })
                .Select(x => x.OrderBy(y => y.PriceDateTime)
                .FirstOrDefault())
                .ToList();

            return list;
        }
    }
}
