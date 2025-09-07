using Buyer_seller_stock.Data;
using Buyer_seller_stock.Models.DTO;
using Buyer_seller_stock.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buyer_seller_stock.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class Buyer_seller : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public Buyer_seller(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        [Route("add-buyer-by-id")]
        public IActionResult addBuyerbyID(BuyerDTO buyerDTO)
        {
            if (buyerDTO == null)
            {
                return BadRequest("Invalid buyer data.");
            }

            var buyerEntity = new Buyer()
            {
                BuyerID = buyerDTO.BuyerID,
                BuyerName = buyerDTO.BuyerName,
                StockID = buyerDTO.StockID,
                TotalFunds = buyerDTO.TotalFunds,
                TotalQuantity = buyerDTO.TotalQuantity,
                BuyingPrice = buyerDTO.BuyingPrice
            };
            dbContext.Buyer.Add(buyerEntity);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("add-seller-by-id")]
        public IActionResult AddSellerByID(SellerDTO sellerDTO)
        {
            if (sellerDTO == null)
            {
                return BadRequest("Invalid seller data.");
            }

            var sellerEntity = new Seller()
            {
                SellerID = sellerDTO.SellerID,
                SellerName = sellerDTO.SellerName,
                StockID = sellerDTO.StockID,
                TotalFunds = sellerDTO.TotalFunds,
                TotalQuantity = sellerDTO.TotalQuantity,
                SellingPrice = sellerDTO.SellingPrice
            };
            dbContext.Seller.Add(sellerEntity);
            dbContext.SaveChanges();
            return Ok(sellerEntity);
        }
        [HttpGet]
        [Route("get-all-buyers")]
        public IActionResult GetAllBuyers()
        {
            var buyers = dbContext.Buyer.ToList();

            if (buyers == null || !buyers.Any())
            {
                return NotFound("No buyers found.");
            }

            return Ok(buyers);
        }
        [HttpGet]
        [Route("get-all-seller")]
        public IActionResult GetAllSellers()
        {
            var sellers = dbContext.Seller.ToList();

            if (sellers == null || !sellers.Any())
            {
                return NotFound("No sellers found.");
            }

            return Ok(sellers); // Similar to buyers, you can use DTO projection here.
        }

        [HttpGet]
        [Route("get-buyer-by-id/{id}")]
        public IActionResult GetBuyerByID(int id)
        {
            var buyer = dbContext.Buyer.FirstOrDefault(b => b.BuyerID == id);

            if (buyer == null)
            {
                return NotFound($"Buyer with ID {id} not found.");
            }

            return Ok(buyer); // Or return a DTO if needed.
        }
        [HttpGet]
        [Route("get-seller-by-id/{id}")]
        public IActionResult GetSellerByID(int id)
        {
            var seller = dbContext.Seller.FirstOrDefault(s => s.SellerID == id);

            if (seller == null)
            {
                return NotFound($"Seller with ID {id} not found.");
            }

            return Ok(seller); // Again, you can use DTO projection.
        }

    }
}
