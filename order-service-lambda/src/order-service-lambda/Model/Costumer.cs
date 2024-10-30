namespace order_service_lambda.Model
{
    public class Costumer
    {
        public required string CostumerGuid { get; set; }
        public required string Document { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
