using Buyer_seller_stock.Data;
using Buyer_seller_stock.Models.DTO;
using Buyer_seller_stock.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Buyer_seller_stock.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StockController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost()]
        [Route("add-stock")]
        public IActionResult AddStock([FromBody] StockDTO stockDTO)
        {
            if (stockDTO == null)
            {
                return BadRequest("Stock data is null.");
            }

            var stockEntity = new Stock
            {
                StockId = stockDTO.StockId,
                StockName = stockDTO.StockName,
                Price = stockDTO.Price,
                TotalAvalibleQuantity = stockDTO.TotalAvalibleQuantity,
                UserID = stockDTO.UserID,
                StockSymbol = stockDTO.StockSymbol
            };

            dbContext.Stock.Add(stockEntity);
            dbContext.SaveChanges();

            return Ok(stockEntity);
        }
        [HttpGet]
        [Route("get-all-stock")]
        public IActionResult getallStock()
        {
            var stocksEntity = dbContext.Stock.ToList();
            if (stocksEntity.Count > 0)
            {
                return NotFound("No Stock Present");
            }
            return Ok(stocksEntity);
        }
        [HttpGet]
        [Route("get-stock-by-id/{stockID}")]
        public IActionResult getstock(int stockID) {
            var stockentity = dbContext.Stock.Find(stockID);
            if (stockentity is null) return NotFound();
            return Ok(stockentity);
        }
    }
}
