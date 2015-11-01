using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Product
{
    public class PostProduct : BaseProduct
    {
        [JsonProperty(PropertyName = "variations")]
        public List<PostProductVariation> Variations { get; set; }

        [JsonProperty(PropertyName = "images")]
        public List<PostProductImage> Images { get; set; }

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

            toString.Append("Images: ").AppendLine(Images.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var image in Images)
            {
                toString.Append(image.ToString());
            }

            return toString.ToString();
        }
    }
}
