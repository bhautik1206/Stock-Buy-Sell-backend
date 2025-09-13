namespace Buyer_seller_stock.Models.Entities
{
    public class Buyer
    {
        public required int BuyerID { get; set; }// userID from user table
        public required string BuyerName { get; set; } // user name from user table
        public required int StockID { get; set; }
        public required decimal TotalFunds { get; set; }
        public required int TotalQuantity { get; set; }
        public required int BuyingPrice { get; set; }
    }
}
