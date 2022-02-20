using BookStore;
using BookStore.Model;
using BookStore.ModelFactory;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/book-balance")]
    public class GetBalanceController : ControllerBase
    {
        [HttpGet(Name = "get-balances")]
        public IEnumerable<StockBalance> Get()
        {
            using (ModelContext context = new ModelContext())
            {
                string strBookID = "", strBranchID = "", strPrice = "";
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
                    else if (tempQuery.Key.ToUpper() == "Price")
                    {
                        strPrice = tempQuery.Value.ToString();
                    }
                }

                int bookid = 0;
                if (strBookID != "")
                {
                    bookid = Int32.Parse(strBookID);
                }
                else
                {
                    throw new Exception("Book ID not found");
                }
                int branchid = 0;
                if (strBranchID != "")
                {
                    branchid = Int32.Parse(strBranchID);
                }
                else
                {
                    throw new Exception("Branch ID not found");
                }
                double price = 0;
                if (strPrice != "")
                {
                    price = Convert.ToDouble(strPrice);
                }
                else
                {
                    throw new Exception("Price not found");
                }

                return BalanceFactory.GetInstance().GetBalance(context, bookid, branchid);
                          
            }
        }
    }
}
