using BookStore;
using BookStore.Model;
using BookStore.ModelFactory;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/book-set-sales")]
    public class SetSalesController : ControllerBase
    {
        [HttpGet(Name = "set-balances")]
        public int Get()
        {
            using (ModelContext context = new ModelContext())
            {
                string strBookID = "", strBranchID = "", strQuantity = "", strPrice = "", strMovement = "";
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
                    else if (tempQuery.Key.ToUpper() == "Quantity")
                    {
                        strQuantity = tempQuery.Value.ToString();
                    }
                    else if (tempQuery.Key.ToUpper() == "Price")
                    {
                        strPrice = tempQuery.Value.ToString();
                    }
                    else if (tempQuery.Key.ToUpper() == "Movement")
                    {
                        strMovement = tempQuery.Value.ToString();
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
                int quantity = 0;
                if (strQuantity != "")
                {
                    quantity = Convert.ToInt32(strQuantity);
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

                if (strMovement.ToUpper() == "IN")
                {
                    SalesFactory.GetInstance().SalesIn(context, bookid, branchid, quantity, price);
                }
                else if (strMovement.ToUpper() == "OUT")
                {
                    BalanceFactory.GetInstance().SalesOut(context, bookid, branchid, quantity, price);
                }

                return 200;

            }
        }
    }
}
