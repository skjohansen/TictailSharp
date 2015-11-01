using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Product;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Product repository interface
    /// </summary>
    public interface IProductResource : IGetSpecific<Product>, IGetRange<Product>, IStore, IPut<Product>, IPatch<Product, Product>, IPost<PostProduct, Product>
    {
    }
}
