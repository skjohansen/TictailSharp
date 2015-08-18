using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Store;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Store repository interface
    /// </summary>
    public interface IStoreResource : IGetSpecific<Store>, IPatch<PatchStore, Store>
    {
    }
}
