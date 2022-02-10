using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class Sales
    {
        public int ID { get; set; }
        public BookInfo Book { get; set; }
        public BranchInfo Branch { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
        public TypeOfMovements TypeOfMovement { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
