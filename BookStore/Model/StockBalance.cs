using System;

namespace BookStore.Model
{
    public class StockBalance
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public BookInfo Book { get; set; }
        public int BranchID { get; set; }
        public BranchInfo Branch { get; set; }
        public int Quantity { get; set; }
        public TypeOfMovements TypeOfMovement { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
