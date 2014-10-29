using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Product;

namespace TictailSharp.Api
{
    /// <summary>
    /// Product repository interface
    /// </summary>
    public interface IProductRepository : IGetSpecific<Product>, IGetRange<Product>, IStore
    {
    }
}
