using Amazon.DynamoDBv2.DataModel;
using approve_order_lambda.Repository;
using Ecommerce.Domain.Entities;

namespace approve_order_lambda.Service
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDynamoDBContext _dynamoDbContext;
        public OrderRepository(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<bool> Create(Order order)
        {
            await _dynamoDbContext.SaveAsync(order);
            return true;
        }
    }
}
