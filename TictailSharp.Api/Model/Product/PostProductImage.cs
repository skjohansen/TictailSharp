using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Product
{
    public class PostProductImage : BaseProductImage 
    {
        /// <example>"123-b9593bd5110247a08a393ebec90b8d00.jpeg"</example>
        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }

        /// <example>"jpeg"</example>
        [JsonProperty(PropertyName = "extension")]
        public string Extension { get; set; }
    }
}
