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
            
            //double price = 0;

            //var query1 = dbcontext.BookPrices.GroupBy(x => x.Book).Select(new { });

            //var query = (from b in dbcontext.BookPrices
            //             where (b.Book.Id == bookID && b.Branch.ID == branchID)
            //             orderby b.PriceDateTime descending
            //             select b.Price).Take(1);

            //foreach (var item in query)
            //{
            //    return item;
            //}

            //return price;
        }
    }
}
