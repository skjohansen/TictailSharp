using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
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
        public string Street { get; set; }

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

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Name: ").AppendLine(Name);
            toString.Append("Phone: ").AppendLine(Phone);
            toString.Append("Street: ").AppendLine(Street);
            toString.Append("State: ").AppendLine(State);
            toString.Append("City: ").AppendLine(City);
            toString.Append("Zip: ").AppendLine(Zip);
            toString.Append("Country: ").AppendLine(Country);


            return toString.ToString();
        }
    }
}
