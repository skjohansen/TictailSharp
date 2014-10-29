using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Order
{
    /// <summary>
    /// Transaction part of order
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Status of the order transaction, one of: paid, refunded, pending or denied
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Processor used to pay the order
        /// </summary>
        [JsonProperty(PropertyName = "processor")]
        public string Processor { get; set; }

        /// <summary>
        /// Processor reference, such as transaction number or invoice number
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Timestamp when the transaction was settled
        /// </summary>
        [JsonProperty(PropertyName = "paid_at")]
        public DateTime PaidAt { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Status: ").AppendLine(Status);
            toString.Append("Processor: ").AppendLine(Processor);
            toString.Append("Reference: ").AppendLine(Reference);
            toString.Append("PaidAt: ").AppendLine(PaidAt.ToString(CultureInfo.InvariantCulture));
            return toString.ToString();

        }
    }
}
