namespace Ecommerce.Domain.Entities
{
    public class NFe
    {
        public string DocCostumer { get; set; }
        public string IdNfe { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal AliquotaTributo { get; set; }
        public string Description { get; set; }
        public decimal Value { 
            get 
            { 
                return BaseCalculo * AliquotaTributo / 100; 
            } 
            private set 
            { 
                Value = value; 
            } 
        }
    }
}
