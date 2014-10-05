using System;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public abstract class BaseVat
    {
        /// <summary>
        /// VAT rate set by the store
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public Decimal Rate { get; set; }
    
    }
}
