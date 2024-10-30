
using Ecommerce.Domain.Entities;

namespace order_service_lambda.Service
{
    public interface IOrderService
    {
        Task<Order> Get(string guid);
        Task<IEnumerable<Order>> GetList();
        Task<bool> Put(Order order);
        Task<bool> Post(Order order);
        Task<bool> Delete(string guid);
    }
}
