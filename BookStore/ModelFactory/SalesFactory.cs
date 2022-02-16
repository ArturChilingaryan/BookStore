using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model;

namespace BookStore.ModelFactory
{
    public class SalesFactory {
    {
        private static SalesFactory instance;
        private SalesFactory()
        {
        }

        public static SalesFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new SalesFactory();
            }
            return instance;
        }

        public void SalesInOut(ModelContext dbcontext, int bookID, int branchID, int quantity, double price, TypeOfMovements typeOfMovements)
        {
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

            Sales sale = new Sales
            {
                Book = book,
                Branch = branch,
                Quantity = quantity,
                Sum = quantity * price,
                MovementDate = System.DateTime.Now,
                TypeOfMovement = typeOfMovements
            };

            dbcontext.Sales.Add(sale);
            dbcontext.SaveChanges();

        }

        public void StockIn(ModelContext dbcontext, int bookID, int branchID, int quantity, double price)
        {
            SalesInOut(dbcontext, bookID, branchID, quantity, price, TypeOfMovements.Comming);
        }

        public void StockOut(ModelContext dbcontext, int bookID, int branchID, int quantity, double price)
        {
            SalesInOut(dbcontext, bookID, branchID, -quantity, price, TypeOfMovements.Consumption);
        }

    }
}
