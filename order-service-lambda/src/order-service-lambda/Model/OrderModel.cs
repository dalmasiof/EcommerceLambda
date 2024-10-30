namespace order_service_lambda.Model
{
    public class OrderModel
    {
        public required string Guid { get; set; }
        public  string CostumerDocument => Costumer.Document;
        public StatusOrderEnum StatusOrder { get; set; }
        public Costumer Costumer { get; set; }
        public decimal Total => OrderItens.Sum(x => x.Price);
        public IEnumerable<OrderItem> OrderItens { get; set; }
    }
}
