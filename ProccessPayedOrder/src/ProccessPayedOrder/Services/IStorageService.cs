using Ecommerce.Domain.Entities;

namespace ProccessPayedOrder.Services
{
    public interface IStorageService
    {
        Task SaveNfe(NFe nFe);
    }
}
