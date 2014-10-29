using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Order;

namespace TictailSharp.Api
{
    /// <summary>
    /// Order repository interface
    /// </summary>
    public interface IOrderRepository : IGetRange<Order>, IGetSpecific<Order>, IStore
    {
    }
}
