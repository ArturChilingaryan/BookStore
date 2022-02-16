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
            
            BookInfo book = dbcontext.BookInfos.FirstOrDefault(a => a.Id == bookID);
            if (book == null)
            {
                throw new Exception("No such book with ID: " + bookID);
            }

            BranchInfo branch = dbcontext.BranchInfos.FirstOrDefault(a => a.ID == branchID);
            if (branch == null)
            {
                throw new Exception("No such branch with ID: " + branchID);
            }

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

        public static double GetPrice(ModelContext dbcontext, int bookID, int branchID) {
            double price = 0;
            
            BookInfo book = dbcontext.BookInfos.FirstOrDefault(a => a.Id == bookID);
            if (book == null)
            {
                throw new Exception("No such book with ID: " + bookID);
            }

            BranchInfo branch = dbcontext.BranchInfos.FirstOrDefault(a => a.ID == branchID);
            if (branch == null)
            {
                throw new Exception("No such branch with ID: " + branchID);
            }

            //dbcontext.BookPrices.GroupBy(p => p.Branch).OrderBy(p => p.PriceDate)

            return price;
        }
    }
}
