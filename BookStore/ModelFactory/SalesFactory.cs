using BookStore.Model;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.ModelFactory
{
    public class SalesFactory
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

        private void SalesInOut(ModelContext dbcontext, int bookID, int branchID, int quantity, double price, TypeOfMovements typeOfMovements)
        {
            BookInfo book = BookFactory.GetInstance().GetBookByID(dbcontext, bookID);
            BranchInfo branch = BranchFactory.GetInstance().GetBranchInfoByID(dbcontext, branchID);

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

        public void SalesIn(ModelContext dbcontext, int bookID, int branchID, int quantity, double price)
        {
            SalesInOut(dbcontext, bookID, branchID, quantity, price, TypeOfMovements.Comming);
        }

        public void SalesOut(ModelContext dbcontext, int bookID, int branchID, int quantity, double price)
        {
            SalesInOut(dbcontext, bookID, branchID, -quantity, price, TypeOfMovements.Consumption);
        }
        public List<Sales> GetBalance(ModelContext dbcontext, int bookID, int branchID)
        {

            var list = dbcontext.Sales
                .Where(x => ((x.BranchId == branchID || branchID == 0) && (x.BookId == bookID || bookID == 0)))
                .GroupBy(x => new { x.BranchId, x.BookId })
                .Select(x => x.Sum(y => y.Sum))
                .ToList();

            return null;
        }
    }
}
