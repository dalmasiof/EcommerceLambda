using Amazon.DynamoDBv2.DataModel;

namespace Ecommerce.Domain.Entities
{
    public class Order
    {
        public required string Guid { get; set; }
        public string CostumerDocument
        {
            get 
            { 
                return this.Costumer.Document; 
            }
            private set 
            {
                this.CostumerDocument = value; 
            }
        }
        [DynamoDBHashKey(typeof(DybnamoDbEnumStringConverter<StatusOrderEnum>))]
        public StatusOrderEnum StatusOrder { get; set; }
        public Costumer Costumer { get; set; }
        public decimal Total => OrderItens.Sum(x => x.Price);
        public List<OrderItem> OrderItens { get; set; }
    }
}
