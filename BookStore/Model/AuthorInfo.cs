
using System.Collections.Generic;

namespace BookStore.Model
{
    public class AuthorInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<BookInfo> Books { get; set; }
    }
}
