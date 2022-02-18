
namespace BookStore.Model
{
    public class BookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public BookGenre Genre { get; set; }
        public int AuthorId { get; set; }
        public AuthorInfo Author { get; set; }
    }
}
