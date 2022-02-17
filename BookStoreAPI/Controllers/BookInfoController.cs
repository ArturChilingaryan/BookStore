using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore;
using System.Linq;

namespace BookStoreAPI.Controllers
{
    public class BookInfoView {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }
        public string Author { get; set; }
        public int GenreID { get; set; }
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
                string strID = "";
                foreach (var tempQuery in Request.Query) {
                    if (tempQuery.Key.ToUpper() == "ID")
                    {
                        strID = tempQuery.Value.ToString();
                    }
                }
                List<BookInfoView> list = new List<BookInfoView>();

                int id = 0;
                if (strID != "") {
                    id = Int32.Parse(strID);
                }
                var queryWithID = from b in context.BookInfos
                                  where (b.Id == id || id ==0)
                                  select new
                                  {
                                    ID          = b.Id,
                                    Name        = b.Name,
                                    Author      = b.Author.Name,
                                    AuthorID    = b.Author.ID,
                                    Genre       = b.Genre.Name,
                                    GenreID     = b.Genre.ID
                                   };

                 foreach (var item in queryWithID)
                 {
                    list.Add(new BookInfoView
                    {
                        Id = item.ID,
                        Name = item.Name,
                        AuthorID = item.AuthorID,
                        Author = item.Author,
                        GenreID = item.GenreID,
                        Genre = item.Genre
                    });
                        
                 }
                

                return list;

            }
        }
    }
}