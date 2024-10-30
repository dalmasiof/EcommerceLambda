using Amazon.SQS;
using Amazon.SQS.Model;

namespace order_service_lambda.MessageService
{
    public class OrderMessageService : IOrderMessageService
    {
        private readonly IAmazonSQS sqsClient;

        public OrderMessageService(IAmazonSQS sqsClient)
        {
            this.sqsClient = sqsClient;
        }

        public async Task<bool> SendMessage(string message)
        {
            var request = new SendMessageRequest()
            {
                MessageBody = message,
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/442042514714/order-queue-sqs"
            };

            await sqsClient.SendMessageAsync(request);
            return true;
        }
    }
}
