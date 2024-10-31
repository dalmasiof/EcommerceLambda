using Amazon.DynamoDBv2.DataModel;
using Amazon.SQS;
using approve_order_lambda.Message;
using approve_order_lambda.Repository;
using Ecommerce.Domain.Entities;
using Newtonsoft.Json;

namespace approve_order_lambda.Service
{
    public class OrderApproveService : IOrderApproveService
    {
        private readonly IAmazonSQS sqsClient;
        private readonly IOrderRepository orderRepository;
        private readonly IMessageService messageService;
        public OrderApproveService(IOrderRepository orderRepository, IAmazonSQS sqsClient, IMessageService messageService)
        {
            this.orderRepository = orderRepository;
            this.sqsClient = sqsClient;
            this.messageService = messageService;
        }
        public async Task<bool> Approve(Order order)
        {
            try
            {
                ValidateOrder(order);
                order.StatusOrder = StatusOrderEnum.PAYED.ToString();
                await orderRepository.Create(order);
                await messageService.SendMessage(JsonConvert.SerializeObject(order));
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        private void ValidateOrder(Order order)
        {
            if (order.CostumerDocument == null) throw new Exception("Document is required");

            if (order.Total != order.OrderItens.Sum(x => x.Price)) throw new Exception("Total must be equal of OrderItens Sum");
        }
    }
}
