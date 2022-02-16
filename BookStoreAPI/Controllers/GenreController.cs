using BookStore;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/genre-info")]
    public class GenreController : ControllerBase
    {
        [HttpGet(Name = "get-genre")]
        public IEnumerable<BookGenre> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                return context.BookGenres.ToList();

            }
        }
    }
}
