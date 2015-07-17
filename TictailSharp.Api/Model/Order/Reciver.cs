using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Order
{
    /// <summary>
    /// Reciver of the order
    /// </summary>
    public class Reciver
    {
        /// <summary>
        /// Full name of the receiver
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Phone number to receiver
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Street of the receivers address
        /// </summary>
        [JsonProperty(PropertyName = "street")]
        public string Street1 { get; set; }

        /// <summary>
        /// Second address line of the order receiver
        /// </summary>
        [JsonProperty(PropertyName = "street_line2")]
        public string Street2 { get; set; }

        /// <summary>
        /// State of the receivers address
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// City of the receivers address
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// Zipcode of the receivers address
        /// </summary>
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Country of the receivers address
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Name: ").AppendLine(Name);
            toString.Append("Phone: ").AppendLine(Phone);
            toString.Append("Street1: ").AppendLine(Street1);
            toString.Append("Street2: ").AppendLine(Street2);
            toString.Append("State: ").AppendLine(State);
            toString.Append("City: ").AppendLine(City);
            toString.Append("Zip: ").AppendLine(Zip);
            toString.Append("Country: ").AppendLine(Country);


            return toString.ToString();
        }
    }
}
