using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class Item : BaseItem
    {
        /// <summary>
        /// The product this line item refers to, with a specified variation, see line item object for details
        /// </summary>
        [JsonProperty(PropertyName = "product")]
        public Product Product { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Quantity: ").AppendLine(Quantity.ToString(CultureInfo.InvariantCulture));
            toString.Append("Product: ").AppendLine(Product.ToString());
            return toString.ToString();
        }
    }
}
