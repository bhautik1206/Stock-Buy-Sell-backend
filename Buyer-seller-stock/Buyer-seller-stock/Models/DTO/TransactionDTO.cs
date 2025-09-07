namespace Buyer_seller_stock.Models.DTO
{
    public class TransactionDTO
    {
        public required int TransactionID { get; set; }
        public required int BuyerID { get; set; }
        public required int SellerID { get; set; }
        public required int StockID { get; set; }
        public required int TotalQunaity { get; set; }
        public DateTime? TransationTime { get; set; }
        public required int Pricing { get; set; }
    }
}
