using Ecommerce.Domain.Entities;

namespace ProccessPayedOrder.Services
{
    public interface IProcessPayedService
    { 
        Task Process(Order Order);
    }
}
