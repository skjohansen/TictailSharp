using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class OrderVat : BaseVat
    {
        /// <summary>
        /// The total amount of VAT in cents, will be zero if VAT not applied
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        /// <summary>
        /// The currency that the tax is applied in.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Rate: ").AppendLine(Rate.ToString(CultureInfo.InvariantCulture));
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            return toString.ToString();
        }
    }
}
