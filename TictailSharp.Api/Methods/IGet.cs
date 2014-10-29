namespace TictailSharp.Api.Methods
{
    /// <summary>
    /// Make GET request to the Tictail API
    /// </summary>
    /// <typeparam name="TResource">TictailSharp resource</typeparam>
    public interface IGet<out TResource>
    {
        /// <summary>
        /// Request Tictail API
        /// </summary>
        /// <returns>TictailSharp resource</returns>
        TResource Get();
        
        /// <summary>
        /// Deserialize the result from the Tictail API
        /// </summary>
        /// <param name="data">Data to deserilize</param>
        /// <returns>TictailSharp model</returns>
        TResource DeserializeGet(string data);
    }
}
