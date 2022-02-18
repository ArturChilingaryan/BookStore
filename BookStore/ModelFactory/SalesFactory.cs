using BookStore.Model;

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

    }
}
