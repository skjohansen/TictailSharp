﻿using Newtonsoft.Json;
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
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Unlimited: ").AppendLine(Unlimited.ToString());
            if (Quantity.HasValue)
            {
                toString.Append("Quantity: ").AppendLine(Quantity.Value.ToString(CultureInfo.InvariantCulture));
            }
            return toString.ToString();
        }
    }
}
