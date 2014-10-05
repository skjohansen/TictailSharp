using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class Order
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Order number as seen in the Dashboard
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// The total price of the order, in cents
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        /// <summary>
        /// Currency code (ISO 4217) that was used in the transaction
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Invoice fee applied to this order
        /// </summary>
        [JsonProperty(PropertyName = "invoice_fee")]
        public int InvoiceFee { get; set; }

        /// <summary>
        /// An optional note from customer
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        /// <summary>
        /// Do prices for items and shipping include VAT?
        /// </summary>
        [JsonProperty(PropertyName = "prices_include_vat")]
        public bool PricesIncludeVat { get; set; }

        /// <summary>
        /// Transaction details, see transaction object for details
        /// </summary>
        [JsonProperty(PropertyName = "transaction")]
        public Transaction Transaction { get; set; }
        
        /// <summary>
        /// Fullfilment details, see fullfilment object for details
        /// </summary>
        [JsonProperty(PropertyName = "fullfilment")]
        public Fullfillment Fullfillment { get; set; }

         
        /// <summary>
        /// Customer, see customer object for details
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }
        
        /// <summary>
        /// VAT applied for this order, see VAT object for details
        /// </summary>
        [JsonProperty(PropertyName = "vat")]
        public OrderVat Vat { get; set; }
        
        /// <summary>
        /// List of order items, see order item for details
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<OrderItem> Items { get; set; }
        
        /// <summary>
        /// List of applied discounts, see discount object for details
        /// </summary>
        [JsonProperty(PropertyName = "discounts")]
        public List<Discount> Discounts { get; set; }
        
        /// <summary>
        /// Used shipping alternative, see shipping alternative object for details
        /// </summary>
        [JsonProperty(PropertyName = "shipping_alternative")]
        public ShippingAlternative ShippingAlternative { get; set; }
        
        /// <summary>
        /// Timestamp when this order was created
        /// </summary>
        /// <example>2013-12-18T21:57:07</example>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this order was modified
        /// </summary>
        /// <example>2013-12-18T21:57:07</example>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Number: ").AppendLine(Number.ToString(CultureInfo.InvariantCulture));
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("InvoiceFee: ").AppendLine(InvoiceFee.ToString(CultureInfo.InvariantCulture));
            toString.Append("Note: ").AppendLine(Note);
            toString.Append("PricesIncludeVat: ").AppendLine(PricesIncludeVat.ToString());
            toString.Append("Transaction: ").AppendLine(Transaction.ToString());
            toString.Append("Fullfilment: ").AppendLine(Fullfillment.ToString());
            toString.Append("Customer: ").AppendLine(Customer.ToString());
            toString.Append("Vat: ").AppendLine(Vat.ToString());
            toString.Append("items: ").AppendLine(Items.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var item in Items)
            {
                toString.AppendLine(item.ToString());
            }
            toString.Append("discounts: ").AppendLine(Discounts.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var discount in Discounts)
            {
                toString.AppendLine(discount.ToString());
            }
            
            toString.Append("ShippingAlternative: ").AppendLine(ShippingAlternative.ToString());
            
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }
            
            return toString.ToString();
        }
    }
}
