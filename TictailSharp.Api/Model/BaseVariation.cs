using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// Base properties of an variation
    /// </summary>
    public abstract class BaseVariation
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

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
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
