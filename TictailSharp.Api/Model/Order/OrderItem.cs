using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Order
{
    /// <summary>
    /// An order item, contains a product
    /// </summary>
    public class OrderItem : BaseItem
    {
        /// <summary>
        /// The product this line item refers to, with a specified variation, see line item object for details
        /// </summary>
        [JsonProperty(PropertyName = "product")]
        public OrderProduct Product { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append(base.ToString());
            toString.Append("Product: ").AppendLine(Product.ToString());
            return toString.ToString();
        }
    }
}
