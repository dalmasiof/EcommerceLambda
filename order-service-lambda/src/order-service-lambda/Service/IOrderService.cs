using order_service_lambda.Model;

namespace order_service_lambda.Service
{
    public interface IOrderService
    {
        Task<OrderModel> Get(string guid);
        Task<IEnumerable<OrderModel>> GetList();
        Task<bool> Put(OrderModel order);
        Task<bool> Post(OrderModel order);
        Task<bool> Delete(string guid);
    }
}
