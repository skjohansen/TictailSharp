using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class Product : BaseProduct
    {
        /// <summary>
        /// List with the different variations of this product, empty if no variations
        /// </summary>
        /// 
        [JsonProperty(PropertyName = "variations")]
        public List<Variation> Variations { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("Status: ").AppendLine(Status);
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Slug: ").AppendLine(Slug);
            toString.Append("Unlimited: ").AppendLine(Unlimited.ToString());
            if (Quantity.HasValue)
            {
                toString.Append("Quantity: ").AppendLine(Quantity.Value.ToString(CultureInfo.InvariantCulture));
            }
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }
            toString.Append("Variations: ").AppendLine(Variations.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var variation in Variations)
            {
                toString.Append(variation.ToString());
            }
            toString.AppendLine().Append("Images: ").AppendLine(Images.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var image in Images)
            {
                toString.AppendLine(image.ToString());
            }

            return toString.ToString();
        }
    }
}
