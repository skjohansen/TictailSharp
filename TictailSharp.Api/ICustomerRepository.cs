using System.Collections.Generic;
using TictailSharp.Api.Methods;
using TictailSharp.Api.Model;

namespace TictailSharp.Api
{
    public interface ICustomerRepository : IGetSpecific<Customer>, IGetRange<Customer>, IEnumerable<Customer>, IStore
    {
    }
}
