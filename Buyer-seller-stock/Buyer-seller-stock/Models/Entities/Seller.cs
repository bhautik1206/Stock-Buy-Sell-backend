namespace Buyer_seller_stock.Models.Entities
{
    public class Seller
    {
        public required int SellerID { get; set; }// userID from user table
        public required string SellerName { get; set; } // user name from user table
        public required int StockID { get; set; }
        public required decimal TotalFunds { get; set; }
        public required int TotalQuantity { get; set; }
        public required int SellingPrice { get; set; }
    }
}
