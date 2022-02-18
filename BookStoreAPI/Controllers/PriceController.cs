using BookStore;
using BookStore.Model;
using BookStore.ModelFactory;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/book-prices")]
    public class PriceController : ControllerBase
    {
        [HttpGet(Name = "get-prices")]
        public IEnumerable<BookPrice> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                string strBookID = "", strBranchID = "";
                foreach (var tempQuery in Request.Query)
                {
                    if (tempQuery.Key.ToUpper() == "BookID")
                    {
                        strBookID = tempQuery.Value.ToString();
                    }
                    else if (tempQuery.Key.ToUpper() == "BranchID")
                    {
                        strBranchID = tempQuery.Value.ToString();
                    }
                }
                
                int bookid = 0;
                if (strBookID != "")
                {
                    bookid = Int32.Parse(strBookID);
                }
                int branchid = 0;
                if (strBranchID != "")
                {
                    branchid = Int32.Parse(strBranchID);
                }
                
                return PriceFactory.GetInstance().GetPrice(context, bookid, branchid);

            }
        }
    }
}
