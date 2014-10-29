using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Store
{
    /// <summary>
    /// Store with repositories
    /// </summary>
    public class Store : BaseStore
    {
        /// <summary>
        /// Repository of products
        /// </summary>
        [JsonIgnore]
        public IProductRepository Products { get; set; }

        /// <summary>
        /// Repository of theme
        /// </summary>
        [JsonIgnore]
        public IThemeRepository Theme { get; set; }

        /// <summary>
        /// Repository of categories
        /// </summary>
        [JsonIgnore]
        public ICategoryRepository Categories { get; set; }

        /// <summary>
        /// Repository of customers
        /// </summary>
        [JsonIgnore]
        public ICustomerRepository Customers { get; set; }

        /// <summary>
        /// Repository of followers
        /// </summary>
        [JsonIgnore]
        public IFollowerRepository Followers { get; set; }

        /// <summary>
        /// Repository of orders
        /// </summary>
        [JsonIgnore]
        public IOrderRepository Orders { get; set; }

        //TODO: card

    }
}
