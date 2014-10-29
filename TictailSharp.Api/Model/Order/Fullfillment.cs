using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Order
{
    /// <summary>
    /// Fullfillment of the order (current status of the order)
    /// </summary>
    public class Fullfillment
    {
        /// <summary>
        /// Status of the order fullfilment, one of: unhandled, shipped, cancelled or refunded
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Order receiver, see receiver object for details
        /// </summary>
        [JsonProperty(PropertyName = "receiver")]
        public Reciver Receiver { get; set; }

        /// <summary>
        /// Tracking number of order provided by store owner upon shipping
        /// </summary>
        [JsonProperty(PropertyName = "tracking_number")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Name of forwarder agent fullfilling the order
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Timestamp when order was shipped
        /// </summary>
        [JsonProperty(PropertyName = "shipped_at")]
        public DateTime? ShippedAt { get; set; }

        /// <summary>
        /// The total price of the shipping paid by the customer, in cents
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        /// <summary>
        /// Currency code (ISO 4217) of the shipping price
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// VAT object, see VAT object for details
        /// </summary>
        [JsonProperty(PropertyName = "vat")]
        public OrderVat Vat { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Status: ").AppendLine(Status);
            toString.Append("Receiver: ").AppendLine(Receiver.ToString());
            toString.Append("TrackingNumber: ").AppendLine(TrackingNumber);
            toString.Append("Provider: ").AppendLine(Provider);
            if (ShippedAt.HasValue)
            {
                toString.Append("ShippedAt: ").AppendLine(ShippedAt.Value.ToString(CultureInfo.InvariantCulture));
            }
            toString.Append("Price: ").AppendLine(Price.ToString());
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Vat: ").AppendLine(Vat.ToString());
            return toString.ToString();
        }
    }
}
