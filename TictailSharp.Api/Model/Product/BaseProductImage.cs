using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Product
{
    public abstract class BaseProductImage
    {
        /// <summary>
        /// Width of original image
        /// </summary>
        [JsonProperty(PropertyName = "original_width")]
        public uint OriginalWidth { get; set; }

        /// <summary>
        /// Height of original image
        /// </summary>
        [JsonProperty(PropertyName = "original_height")]
        public uint OriginalHeight { get; set; }
    }
}
