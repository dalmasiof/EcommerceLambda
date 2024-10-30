using order_service_lambda.MessageService;
using order_service_lambda.Model;
using Newtonsoft.Json;

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

        public Task<OrderModel> Get(string guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderModel>> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(OrderModel order)
        {
            var stringMessage = JsonConvert.SerializeObject(order);
            return await orderMessageService.SendMessage(stringMessage);
        }

        public Task<bool> Put(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
