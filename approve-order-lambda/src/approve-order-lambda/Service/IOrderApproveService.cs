using Ecommerce.Domain.Entities;

namespace approve_order_lambda.Service
{
    public interface IOrderApproveService
    {
        Task<bool> Approve(Order order);
    }
}
