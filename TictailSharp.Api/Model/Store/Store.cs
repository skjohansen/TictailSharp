using Newtonsoft.Json;
using TictailSharp.Api.Resources;

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
        public IProductResource Products { get; set; }

        /// <summary>
        /// Repository of theme
        /// </summary>
        [JsonIgnore]
        public IThemeResource Theme { get; set; }

        /// <summary>
        /// Repository of categories
        /// </summary>
        [JsonIgnore]
        public ICategoryResource Categories { get; set; }

        /// <summary>
        /// Repository of customers
        /// </summary>
        [JsonIgnore]
        public ICustomerResource Customers { get; set; }

        /// <summary>
        /// Repository of followers
        /// </summary>
        [JsonIgnore]
        public IFollowerResource Followers { get; set; }

        /// <summary>
        /// Repository of orders
        /// </summary>
        [JsonIgnore]
        public IOrderResource Orders { get; set; }

        //TODO: card

    }
}
