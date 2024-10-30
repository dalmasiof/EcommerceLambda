namespace order_service_lambda.MessageService
{
    public interface ISqsMessageService
    {
        Task<bool> SendMessage(string message);

    }
}
