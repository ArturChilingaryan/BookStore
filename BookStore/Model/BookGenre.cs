
using System.Collections.Generic;

namespace BookStore.Model
{
    public class BookGenre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<BookInfo> Books { get; set; }
    }
}
