using System.Collections.Generic;

namespace TictailSharp.Api.Methods
{
    public interface IGetRange<out TResource> : IEnumerable<TResource>
    {
        IEnumerator<TResource> GetRange();
        IEnumerator<TResource> DeserializeRangeGet(string value);
        
    }
}
