using Ecommerce.Domain.Entities;

namespace ProccessPayedOrder.Services
{
    public class ProcessPayedService : IProcessPayedService
    {
        private readonly IStorageService storageService;

        public ProcessPayedService(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async Task Process(Order order)
        {
            var nfe = new NFe()
            {
                DocCostumer = order.CostumerDocument,
                IdNfe = Guid.NewGuid().ToString(),
                BaseCalculo = order.Total,
                AliquotaTributo = 20,
                Description = $"NFe related of order {order.Guid}"
            };

            await storageService.SaveNfe(nfe);
        }
    }
}
