using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace approve_order_lambda
{
    public class Function
    {

        public async Task FunctionHandler(SQSEvent input, ILambdaContext context)
        {
            foreach (var message in input.Records)
            {
                await ProcessMessage(message, context);
            }
        }

        private async Task ProcessMessage(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.Log("Message processed");
            context.Logger.Log(message.Body);
        }
    }
}
