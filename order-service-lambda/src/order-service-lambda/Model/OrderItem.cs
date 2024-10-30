namespace order_service_lambda.Model
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public required string ProductGuid { get; set; }
    }
}
