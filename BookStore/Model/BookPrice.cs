using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class BookPrice
    {
        public int ID { get; set; }
        public BookInfo Book { get; set; }
        public BranchInfo Branch { get; set; }
        public double Price { get; set; }
        public DateTime PriceDateTime { get; set; }
    }
}
