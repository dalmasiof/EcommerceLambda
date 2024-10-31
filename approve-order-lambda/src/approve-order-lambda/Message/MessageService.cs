
using Amazon.SQS;
using Amazon.SQS.Model;

namespace approve_order_lambda.Message
{
    public class MessageService : IMessageService
    {
        private readonly IAmazonSQS amazonSQS;
        public MessageService(IAmazonSQS _amazonSQS)
        {
            amazonSQS = _amazonSQS;
        }
        public async Task<bool> SendMessage(string message)
        {
            var request = new SendMessageRequest()
            {
                MessageBody = message,
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/442042514714/payed-order-sqs"
            };

            await amazonSQS.SendMessageAsync(request);
            return true;
        }
    }
}
