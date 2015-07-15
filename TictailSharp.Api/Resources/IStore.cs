namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Interface for resources which is part of stores
    /// </summary>
    public interface IStore
    {
        /// <summary>
        /// ID of the store the ressource is part of
        /// </summary>
        string StoreId { get; set; }
    }
}
