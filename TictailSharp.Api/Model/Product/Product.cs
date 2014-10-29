using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Product
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : BaseProduct
    {
        /// <summary>
        /// List with the different variations of this product, empty if no variations
        /// </summary>
        /// 
        [JsonProperty(PropertyName = "variations")]
        public List<Variation> Variations { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append(base.ToString());
            toString.Append("Variations: ").AppendLine(Variations.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var variation in Variations)
            {
                toString.Append(variation.ToString());
            }

            return toString.ToString();
        }
    }
}
