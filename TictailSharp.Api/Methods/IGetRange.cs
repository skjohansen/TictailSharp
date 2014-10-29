using System.Collections.Generic;

namespace TictailSharp.Api.Methods
{
    /// <summary>
    /// Make GET request to the Tictail API
    /// </summary>
    /// <typeparam name="TResource">TictailSharp resource</typeparam>
    public interface IGetRange<out TResource> : IEnumerable<TResource>
    {
        /// <summary>
        /// Request Tictail API
        /// </summary>
        /// <returns>An IEnumerator of TictailSharp resources</returns>
        IEnumerator<TResource> GetRange();

        /// <summary>
        /// Deserialize the result from the Tictail API
        /// </summary>
        /// <param name="data">Data to deserilize</param>
        /// <returns>An IEnumerator of TictailSharp resources</returns>
        IEnumerator<TResource> DeserializeRangeGet(string data);
        
    }
}
