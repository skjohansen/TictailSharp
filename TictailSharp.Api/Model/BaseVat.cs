using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// Vat
    /// </summary>
    public abstract class BaseVat
    {
        /// <summary>
        /// VAT rate set by the store
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public Decimal Rate { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>String containing all properties of BaseVat</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Rate: ").AppendLine(Rate.ToString(CultureInfo.InvariantCulture));
            return toString.ToString();
        }
    }
}
