using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace Ecommerce.Domain
{
    public class DybnamoDbEnumStringConverter<TEnum> : IPropertyConverter
    {
        public object FromEntry(DynamoDBEntry entry)
        {
            return Enum.Parse(typeof(Enum), entry.AsString());
        }

        public DynamoDBEntry ToEntry(object value)
        {
            return new Primitive(value.ToString());
        }
    }
}
