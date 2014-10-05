using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class Vat : BaseVat
    {

        /// <summary>
        /// The region where VAT is applicable
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    
        /// <summary>
        /// Shows whether prices for this store (for items and shipping) include VAT or not
        /// </summary>
        [JsonProperty(PropertyName = "included_in_prices")]
        public bool IncludedInPrices { get; set; }

        /// <summary>
        /// Shows whether the same VAT rate will be applied on the shipping costs
        /// </summary>
        [JsonProperty(PropertyName = "applied_to_shipping")]
        public bool AppliedToShipping { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Rate: ").AppendLine(Rate.ToString(CultureInfo.InvariantCulture));
            toString.Append("Region: ").AppendLine(Region);
            toString.Append("IncludedInPrices: ").AppendLine(IncludedInPrices.ToString());
            toString.Append("AppliedToShipping: ").AppendLine(AppliedToShipping.ToString());
            return toString.ToString();
        }
    }
}
