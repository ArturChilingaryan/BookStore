using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.ModelFactory
{
    public class BalanceFactory
    {
        private static BalanceFactory instance;
        private BalanceFactory()
        {
        }

        public static BalanceFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new BalanceFactory();
            }
            return instance;
        }

        public void StockInOut(ModelContext dbcontext, int bookID, int branchID, int quantity, TypeOfMovements typeOfMovement)
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

            StockBalance stock = new StockBalance
            {
                Book = book,
                Branch = branch,
                Quantity = quantity,
                MovementDate = System.DateTime.Now,
                TypeOfMovement = typeOfMovement
            };

            dbcontext.StockBalances.Add(stock);
            dbcontext.SaveChanges();
        }
        public void StockIn(ModelContext dbcontext, int bookID, int branchID, int quantity)
        {
            StockInOut(dbcontext, bookID, branchID, quantity, TypeOfMovements.Comming);
        }

        public void StockOut(ModelContext dbcontext, int bookID, int branchID, int quantity)
        {
            StockInOut(dbcontext, bookID, branchID, -quantity, TypeOfMovements.Consumption);
        }

    }
}
