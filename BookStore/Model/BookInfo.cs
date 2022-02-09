
namespace BookStore.Model
{
    public class BookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BookGenre Genre { get; set; }
        public AuthorInfo Author { get; set; }
    }
}
