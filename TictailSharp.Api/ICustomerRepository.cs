using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Customer;

namespace TictailSharp.Api
{   
    /// <summary>
    /// Customer repository interface
    /// </summary>
    public interface ICustomerRepository : IGetSpecific<Customer>, IGetRange<Customer>, IStore
    {
    }
}
