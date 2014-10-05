using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class Discount
    {
        /// <summary>
        /// Discount identifer
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Discount title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Discount status, one of: published, unpublished, deleted
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Discount type, one of: percent_off, money_off
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Discount amount, in percentage for discount_off and in cents for money_off
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Minimum price when this discount is applied, in cents
        /// </summary>
        [JsonProperty(PropertyName = "minimum_price")]
        public int MinimumPrice { get; set; }

        /// <summary>
        /// Is this discount available for all products in the store?
        /// </summary>
        [JsonProperty(PropertyName = "storewide")]
        public bool Storewide { get; set; }

        // TODO: Implement
        /// <summary>
        /// Which categories and products is this discount applicable to
        /// </summary>
        //[JsonProperty(PropertyName = "applicable_to")]
        //public string ApplicableTo { get; set; }

        //        "applicable_to": {
        //  "products": [], 
        //  "categories": []
        //}, 

        /// <summary>
        /// Timestamp when this discount was created
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this discount was last modified
        /// </summary>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Currency in which the discount is applied
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }


        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Id: ").AppendLine(Id);
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Status: ").AppendLine(Status);
            toString.Append("Type: ").AppendLine(Type);
            toString.Append("Amount: ").AppendLine(Amount.ToString(CultureInfo.InvariantCulture));
            toString.Append("MinimumPrice: ").AppendLine(MinimumPrice.ToString(CultureInfo.InvariantCulture));
            toString.Append("Storewide: ").AppendLine(Storewide.ToString());
            //toString.Append("ApplicableTo: ").AppendLine(ApplicableTo);
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }
            toString.Append("Currency: ").AppendLine(Currency);
            return toString.ToString();
        }
    }
}
