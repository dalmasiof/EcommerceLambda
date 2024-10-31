using Ecommerce.Domain.Entities;

namespace approve_order_lambda.Repository
{
    public interface IOrderRepository
    {
        Task<bool> Create(Order order);
    }
}
