using TictailSharp.Api.Methods;
using TictailSharp.Api.Model;

namespace TictailSharp.Api
{
    public interface IProductRepository : IGetSpecific<Product>, IGetRange<Product>, IStore
    {
    }
}
