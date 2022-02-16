using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/author-info")]
    public class AuthorInfoController : ControllerBase
    {
        [HttpGet(Name = "get-authors")]
        public IEnumerable<AuthorInfo> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                return context.AuthorInfos.ToList();

            }
        }
    }
}
