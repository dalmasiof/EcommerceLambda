using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.SQS;
using approve_order_lambda.Message;
using approve_order_lambda.Repository;
using approve_order_lambda.Service;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace approve_order_lambda
{
    public class Function
    {
        private readonly IOrderApproveService _orderApproveService;

        public Function()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
            serviceCollection.AddScoped<IDynamoDBContext, DynamoDBContext>();
            serviceCollection.AddScoped<IAmazonSQS, AmazonSQSClient>();

            serviceCollection.AddScoped<IOrderApproveService, OrderApproveService>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IMessageService, MessageService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _orderApproveService = serviceProvider.GetService<IOrderApproveService>();
        }

        public async Task FunctionHandler(SQSEvent input, ILambdaContext context)
       {
            foreach (var message in input.Records)
            {
                await ProcessMessage(message, context);
            }
        }

        private async Task ProcessMessage(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.Log("Message received");

            var order = JsonConvert.DeserializeObject<Order>(message.Body);
            
            if(order != null) 
                await _orderApproveService.Approve(order);

        }
    }
}
