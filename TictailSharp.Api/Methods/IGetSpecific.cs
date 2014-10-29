namespace TictailSharp.Api.Methods
{
    /// <summary>
    /// Make GET request for specific resource to the Tictail API
    /// </summary>
    /// <typeparam name="TResource">TictailSharp resource</typeparam>
    public interface IGetSpecific<out TResource>
    {
        /// <summary>
        /// Request Tictail API for a specific resource
        /// </summary>
        /// <param name="resourceId">ID of the resource to retrive</param>
        /// <returns>TictailSharp resource</returns>
        TResource Get(string resourceId);

        /// <summary>
        /// Deserialize the result from the Tictail API
        /// </summary>
        /// <param name="data">Data to deserilize</param>
        /// <returns>TictailSharp resource</returns>
        TResource DeserializeGet(string data);

        /// <summary>
        /// Request Tictail API for a specific resource
        /// </summary>
        /// <param name="resourceId">ID of the resource to retrive</param>
        /// <returns>TictailSharp resource</returns>
        TResource this[string resourceId] { get; }
    }
}
