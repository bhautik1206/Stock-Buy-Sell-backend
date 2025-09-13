using Buyer_seller_stock.Data;
using Buyer_seller_stock.Models.DTO;
using Buyer_seller_stock.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.TimeZoneInfo;

namespace Buyer_seller_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public TransactionController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("get-all-transaction")]
        public IActionResult getAllTransaction()
        {
            var trans = dbContext.Transaction.ToList();
            return Ok(trans);
        }
        [HttpGet]
        [Route("get-all-transaction-by-id{transID}")]
        public IActionResult getAllTransactionByID(int transID)
        {
            var trans = dbContext.Transaction.Find(transID);
            if (trans is null) { return NotFound(); }
            return Ok(trans);
        }
        [HttpPost]
        [Route("add-transaction")]
        public IActionResult addNewTransaction(TransactionDTO transactionDTO)
        {
            if(transactionDTO.BuyerID == transactionDTO.SellerID)
            {
                return BadRequest("Buyer ID and sellerID are same no transaction");
            }
            if(transactionDTO.TotalQunaity <= 0)
            {
                return BadRequest("Please correct the total quantity");
            }

            var transactionEntity = new Transaction()
            {

                TransactionID = transactionDTO.TransactionID,
                BuyerID = transactionDTO.BuyerID,
                SellerID = transactionDTO.SellerID,
                StockID = transactionDTO.StockID,
                TotalQunaity = transactionDTO.TotalQunaity,
                Pricing = transactionDTO.Pricing,
                TransationTime = transactionDTO.TransationTime
            };
            dbContext.Transaction.Add(transactionEntity);
            dbContext.SaveChanges();
            return Ok(transactionEntity);

        }
        [HttpPost]
        [Route("add-transaction-by-sp")]
        public IActionResult addNewTransactionBySP()
        {

            return Ok();
        }
    }
}
