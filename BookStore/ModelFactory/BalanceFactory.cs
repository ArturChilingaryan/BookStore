using BookStore.Model;
using System.Linq;
using System.Collections.Generic;

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

        private void StockInOut(ModelContext dbcontext, int bookID, int branchID, int quantity, TypeOfMovements typeOfMovement)
        {
            BookInfo book = BookFactory.GetInstance().GetBookByID(dbcontext, bookID);
            BranchInfo branch = BranchFactory.GetInstance().GetBranchInfoByID(dbcontext, branchID);

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

        public List<StockBalance> GetBalance(ModelContext dbcontext, int bookID, int branchID)
        {

            var list = dbcontext.StockBalances
                .Where(x => ((x.BranchID == branchID || branchID == 0) && (x.BookID == bookID || bookID == 0)))
                .GroupBy(x => new { x.BranchID, x.BookID })
                .Select(x => x.Sum(y => y.Quantity))
                .ToList();

            return null;
        }
    }
}
