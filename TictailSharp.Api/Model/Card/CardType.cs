using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictailSharp.Api.Model.Card
{
    public enum CardType
    {
        /// <summary>
        /// Content:
        /// Header
        /// Caption
        /// Image*
        /// Youtube*
        /// Vimeo*
        /// 
        /// * = mutually exclusive (only one can be defined)
        /// </summary>
        Media,

        /// <summary>
        /// Content:
        /// Url
        /// </summary>
        Native
    }
}
