using Amazon.DynamoDBv2.DataModel;
using approve_order_lambda.Repository;
using Ecommerce.Domain.Entities;

namespace approve_order_lambda.Service
{
    public class OrderApproveService : IOrderApproveService
    {
        private readonly IOrderRepository orderRepository;
        public OrderApproveService( IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<bool> Approve(Order order)
        {
            try
            {
                if (ValidateOrder(order)) { 
                    await orderRepository.Create(order);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        private bool ValidateOrder(Order order) {
            if (order.CostumerDocument == null) return false;

            if (order.Total != order.OrderItens.Sum(x => x.Price)) return false;

            return true;
        }
    }
}
