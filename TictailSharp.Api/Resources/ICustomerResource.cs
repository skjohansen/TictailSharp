using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Customer;

namespace TictailSharp.Api.Resources
{   
    /// <summary>
    /// Customer repository interface
    /// </summary>
    public interface ICustomerResource : IGetSpecific<Customer>, IGetRange<Customer>, IStore
    {
    }
}
