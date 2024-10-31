namespace approve_order_lambda.Message
{
    public interface IMessageService
    {
        Task<bool> SendMessage(string message);
    }
}
