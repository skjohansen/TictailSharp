using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Order
{
    /// <summary>
    /// Product which is part of an order
    /// </summary>
    public class OrderProduct : ExtendedProduct
    {
        /// <summary>
        /// Different variations on the product
        /// </summary>
        [JsonProperty(PropertyName = "variation")]
        public OrderVariation Variation { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append(base.ToString());
            toString.Append(Variation);
            return toString.ToString();
        }
    }
}
