using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookInfoController : ControllerBase
    {
        
        private readonly ILogger<BookInfoController> _logger;

        public BookInfoController(ILogger<BookInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBooks")]
        public IEnumerable<BookInfo> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                return context.BookInfos.ToList();

            }
        }
    }
}