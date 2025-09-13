namespace Buyer_seller_stock.Models.DTO
{
    public class StockDTO
    {
        public int StockId { get; set; }
        public required string StockName { get; set; }
        public required decimal Price { get; set; }
        public required int TotalAvalibleQuantity { get; set; }
        public int? UserID { get; set; }
        public string ? StockSymbol { get; set; }
    }
}
