using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Category
{
    /// <summary>
    /// The product categories are shown as the store's navigation and allow customers to filter the displayed products by categories that they find interesting.
    /// Categories are implemented as a classical parent-child hierarchy, but is limited to one level of depth. In other words, there could be a parent category called "Clothes" which has the categories "Jeans", "T-Shirts" and more as children.
    /// </summary>
    public class Category
    {

        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Title of this category
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }


        /// <summary>
        /// Parent id of this category, null for top level categories
        /// </summary>
        [JsonProperty(PropertyName = "parent_id")]
        public string ParentId { get; set; }


        /// <summary>
        /// Which position this item has relative to it's parent
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }

        /// <summary>
        /// Number of products in this category
        /// </summary>
        [JsonProperty(PropertyName = "product_count")]
        public int ProductCount { get; set; }
        
        /// <summary>
        /// Timestamp when this product was created
        /// </summary>
        /// <example>2013-12-18T21:57:07</example>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this product was last modified
        /// </summary>
        /// <example>2013-12-18T21:57:07</example>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("ParentId: ").AppendLine(ParentId);
            toString.Append("Position: ").AppendLine(Position.ToString(CultureInfo.InvariantCulture));
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }
            return toString.ToString();
        }
    }
}
