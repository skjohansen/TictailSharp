using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using TictailSharp.Api.Model.Product;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// Base product which defines all comon parts of products
    /// </summary>
    public abstract class BaseProduct
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        /// <example>6uDM</example>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Reference to store this product belongs to
        /// </summary>
        [JsonProperty(PropertyName = "store_id")]
        public string StoreId { get; set; }

        /// <summary>
        /// Name of store this product belongs to
        /// </summary>
        [JsonProperty(PropertyName = "store_name")]
        public string StoreName { get; set; }

        
        /// <summary>
        /// Subdomain of the store this product belongs to
        /// </summary>
        [JsonProperty(PropertyName = "store_subdomain")]
        public string StoreSubdomain { get; set; }

        /// <summary>
        /// URL of store this product belongs to
        /// </summary>
        [JsonProperty(PropertyName = "store_url")]
        public string StoreUrl { get; set; }

        /// <summary>
        /// Title of the product
        /// </summary>
        /// <example>Basil</example>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Description, can include some HTML
        /// </summary>
        /// <example>Nice basil</example>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Status, one of published, unpublished, deleted
        /// </summary>
        /// <example>published</example>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Price, in cents
        /// </summary>
        /// <example>2500</example>
        [JsonProperty(PropertyName = "price")]
        public uint Price { get; set; }

        /// <summary>
        /// Currency for this product as a three-letter code (ISO 4217)
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// An URL-safe slug of this product's title
        /// </summary>
        /// <example>basil</example>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Is there unlimited quantity of this product?
        /// </summary>
        /// <example>False</example>
        [JsonProperty(PropertyName = "unlimited")]
        public bool Unlimited { get; set; }

        /// <summary>
        /// The number of this product left in stock, null if unlimited
        /// </summary>
        /// <example>2</example>
        [JsonProperty(PropertyName = "quantity")]
        public uint? Quantity { get; set; }

        /// <summary>
        /// List with the images of this product
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public List<Image> Images { get; set; }

        /// <summary>
        /// Which categories does this product belong to?
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public List<Category.Category> Categories { get; set; }

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
            toString.Append("StoreId: ").AppendLine(StoreId);
            toString.Append("StoreName: ").AppendLine(StoreName);
            toString.Append("StoreSubdomain: ").AppendLine(StoreSubdomain);
            toString.Append("StoreUrl: ").AppendLine(StoreUrl);
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("Status: ").AppendLine(Status);
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Slug: ").AppendLine(Slug);
            toString.Append("Unlimited: ").AppendLine(Unlimited.ToString());
            if (Quantity.HasValue)
            {
                toString.Append("Quantity: ").AppendLine(Quantity.Value.ToString(CultureInfo.InvariantCulture));
            }
            toString.AppendLine().Append("Images: ").AppendLine(Images.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var image in Images)
            {
                toString.AppendLine(image.ToString());
            }
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }


            return toString.ToString();
        }
    }
}
