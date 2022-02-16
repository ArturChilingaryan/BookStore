using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore;
using System.Linq;

namespace BookStoreAPI.Controllers
{
    public class BookInfoView {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }

    [ApiController]
    [Route("api/book-info")]
    public class BookInfoController : ControllerBase
    {
        [HttpGet(Name = "get-books")]
        public IEnumerable<BookInfoView> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                var query = from b in context.BookInfos
                             select new
                             {
                                 ID = b.Id,
                                 Name = b.Name,
                                 Author = b.Author.Name,
                                 Genre = b.Genre.Name
                             };

                List<BookInfoView> list = new List<BookInfoView>();
                foreach (var item in query) {
                    list.Add(new BookInfoView {Id = item.ID, Name = item.Name, Author = item.Author, Genre = item.Genre });
                }
                

                return list;

            }
        }
    }
}