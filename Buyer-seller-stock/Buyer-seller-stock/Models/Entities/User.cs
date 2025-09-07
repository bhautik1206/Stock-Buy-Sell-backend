namespace Buyer_seller_stock.Models.Entities
{
    public class User
    {
        public required int UserId { get; set; }
        public required int UserName{ get; set;}
        public required int TotalFunds { get; set;}
        //public List<UserStock> ? Stocks { get; set; }
    }
    public class UserStock
    {
        public int StockId { get; set; }
        public int Price { get; set; }
    }
}
