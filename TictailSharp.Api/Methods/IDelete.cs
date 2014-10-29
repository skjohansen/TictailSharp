namespace TictailSharp.Api.Methods
{
    /// <summary>
    /// Make DELETE request to the Tictail API
    /// </summary>
    /// <typeparam name="TResource">Resource to delete</typeparam>
    public interface IDelete<in TResource>
    {
        /// <summary>
        /// Delete a specific resource using the Tictail API
        /// </summary>
        /// <param name="resource">Resource to delete</param>
        /// <returns>True if resource is deleted</returns>
        bool Delete(TResource resource);
    }
}
