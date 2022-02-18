using BookStore;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;

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
