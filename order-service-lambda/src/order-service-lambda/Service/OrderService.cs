using order_service_lambda.MessageService;
using Newtonsoft.Json;
using Ecommerce.Domain.Entities;

namespace order_service_lambda.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderMessageService orderMessageService;

        public OrderService(IOrderMessageService orderMessageService)
        {
            this.orderMessageService = orderMessageService;
        }

        public Task<bool> Delete(string guid)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(string guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(Order order)
        {
            var stringMessage = JsonConvert.SerializeObject(order);
            return await orderMessageService.SendMessage(stringMessage);
        }

        public Task<bool> Put(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
