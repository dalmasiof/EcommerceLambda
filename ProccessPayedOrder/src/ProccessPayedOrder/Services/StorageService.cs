using Amazon.S3;
using Amazon.S3.Model;
using Ecommerce.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace ProccessPayedOrder.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 amazonS3;
        public StorageService(IAmazonS3 amazonS3)
        {
            this.amazonS3 = amazonS3;
        }
        public async Task SaveNfe(NFe nFe)
        {
            var prefix = $"{nFe.DocCostumer}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";
            var key = $"{prefix}/{Guid.NewGuid()}.json";

            var putObjRequest = new PutObjectRequest()
            {
                BucketName = "ecommerce-bucket-fiscal-notes",
                Key = key,
                ContentType = "application/json",
                InputStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(nFe)))
            };

            await amazonS3.PutObjectAsync(putObjRequest);
        }
    }
}
