namespace TictailSharp.Api.Methods
{
    /// <summary>
    /// POST a resource to the Tictail API
    /// </summary>
    /// <typeparam name="TResource">TictailSharp resource</typeparam>
    /// <typeparam name="TReturn">TictailSharp resource</typeparam>
    public interface IPost<in TResource, out TReturn>
    {
        /// <summary>
        /// POST a resource to the Tictail API
        /// </summary>
        /// <param name="resource">TictailSharp resource</param>
        /// <returns>TictailSharp resource</returns>
        TReturn Post(TResource resource);
    }
}
