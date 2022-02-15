using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/book-info")]
    public class BookInfoController : ControllerBase
    {
        
        private readonly ILogger<BookInfoController> _logger;

        public BookInfoController(ILogger<BookInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "get-books")]
        public IEnumerable<BookInfo> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                return context.BookInfos.ToList();

            }
        }
    }
}