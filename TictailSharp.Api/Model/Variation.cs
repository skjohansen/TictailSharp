using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public struct Variation
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Variation title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Is there unlimited quantity of this variation?
        /// </summary>
        [JsonProperty(PropertyName = "unlimited")]
        public bool Unlimited { get; set; }

        /// <summary>
        /// Number left of this variation
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public uint? Quantity { get; set; }

        /// <summary>
        /// Timestamp when this variation was created
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this variation was modified
        /// </summary>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime ModifiedAt { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Unlimited: ").AppendLine(Unlimited.ToString());
            if (Quantity.HasValue)
            {
                toString.Append("Quantity: ").AppendLine(Quantity.Value.ToString(CultureInfo.InvariantCulture));
            }
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.ToString(CultureInfo.InvariantCulture));
            return toString.ToString();
        }
    }
}
