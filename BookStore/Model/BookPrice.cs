using System;

namespace BookStore.Model
{
    public class BookPrice
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public BookInfo Book { get; set; }
        public int BranchID { get; set; }
        public BranchInfo Branch { get; set; }
        public double Price { get; set; }
        public DateTime PriceDateTime { get; set; }
    }
}
