using TictailSharp.Api.Methods;
using TictailSharp.Api.Model;

namespace TictailSharp.Api
{
    public interface IOrderRepository : IGetRange<Order>, IGetSpecific<Order>, IStore
    {
    }
}
