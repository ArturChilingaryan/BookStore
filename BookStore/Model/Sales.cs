using System;

namespace BookStore.Model
{
    public class Sales
    {
        public int ID { get; set; }
        public int BookId { get; set; }
        public BookInfo Book { get; set; }
        public int BranchId { get; set; }
        public BranchInfo Branch { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
        public TypeOfMovements TypeOfMovement { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
