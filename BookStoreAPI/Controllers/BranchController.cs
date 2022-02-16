using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/branch-info")]
    public class BranchController : ControllerBase
    {
        [HttpGet(Name = "get-brnach")]
        public IEnumerable<BranchInfo> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                return context.BranchInfos.ToList();

            }
        }
    }
}
