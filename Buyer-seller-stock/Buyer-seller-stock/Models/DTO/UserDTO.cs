namespace Buyer_seller_stock.Models.DTO
{
    public class UserDTO
    {
        public required int UserId { get; set; }
        public required string UserName { get; set; }
        public required int TotalFunds { get; set; } = 0;
        //public List<UserStock>? Stocks { get; set; }
    }
    public class UserStock
    {
        public int StockId { get; set; }
        public int Price { get; set; }
    }
}
