using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class OrderProduct : BaseProduct
    {
        [JsonProperty(PropertyName = "variation")]
        public Variation Variation { get; set; }


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
            toString.Append(Variation);
            toString.AppendLine().Append("Images: ").AppendLine(Images.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var image in Images)
            {
                toString.AppendLine(image.ToString());
            }

            return toString.ToString();
        }
    }
}
