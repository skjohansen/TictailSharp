using System;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Converters
{
    /// <summary>
    /// Converts a ProductStatus to lowercase
    /// </summary>
    public class LowercaseConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string name = Enum.GetName(typeof(ProductStatus), (ProductStatus)value);
            if (string.IsNullOrEmpty(name))
            {
                throw new NoNullAllowedException("Name of a value can't be null");
            }

            JValue jv = new JValue(name.ToLower());
            jv.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ProductStatus productStatus;
            ProductStatus.TryParse(reader.Value.ToString(), true, out productStatus);

            return productStatus;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
