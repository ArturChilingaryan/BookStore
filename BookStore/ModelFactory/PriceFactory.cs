using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model;

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

        public static void SetPrice(ModelContext dbcontext, int bookID, int branchID, double price) {

            BookInfo book = BookFactory.GetInstance().GetBookByID(dbcontext, bookID);
            BranchInfo branch = BranchFactory.GetInstance().GetBranchInfoByID(dbcontext, branchID);

            BookPrice bookPrice = new BookPrice
            {
                Book            = book,
                Branch          = branch,
                Price           = price,
                PriceDateTime   = System.DateTime.Now,
            };

            dbcontext.BookPrices.Add(bookPrice);
            dbcontext.SaveChanges();
        }

        public static double GetPrice(ModelContext dbcontext, int bookID, int branchID) {
            
            double price = 0;

            //var query1 = dbcontext.BookPrices.GroupBy(x => x.Book).Select(new { });

            var query = (from b in dbcontext.BookPrices
                        where (b.Book.Id == bookID && b.Branch.ID == branchID)
                        orderby b.PriceDateTime descending
                        select b.Price).Take(1);

            foreach (var item in query)
            {
                return item;
            }

            return price;
        }
    }
}
