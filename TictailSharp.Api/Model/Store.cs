using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class Store : BaseStore
    {
        [JsonIgnore]
        public IProductRepository Products { get; set; }
        [JsonIgnore]
        public IThemeRepository Theme { get; set; }
        [JsonIgnore]
        public ICategoryRepository Categories { get; set; }
        [JsonIgnore]
        public ICustomerRepository Customers { get; set; }
        [JsonIgnore]
        public IFollowerRepository Followers { get; set; }
        [JsonIgnore]
        public IOrderRepository Orders { get; set; }
        //TODO: card
        
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Name: ").AppendLine(Name);
            toString.Append("ShortDescription: ").AppendLine(ShortDescription);
            toString.Append("NumberOfFollowers: ").AppendLine(NumberOfFollowers.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Vat:").AppendLine(Vat.ToString());
            toString.Append("Language: ").AppendLine(Language);
            toString.Append("Country: ").AppendLine(Country);
            if (Logotypes != null && Logotypes.Count > 0)
            {
                foreach (var logotype in Logotypes)
                {
                    toString.Append("Logotype: ").AppendLine(logotype.ToString());
                }

            }
            //Wallpapers
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("Url: ").AppendLine(Url);
            if (CreatedAt.HasValue)
            {
                toString.Append("CreatedAt: ").AppendLine(CreatedAt.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture));
            }

            toString.Append("ContactEmail: ").AppendLine(ContactEmail);
            toString.Append("StorekeeperEmail: ").AppendLine(StorekeeperEmail);
            toString.Append("Sandbox: ").AppendLine(Sandbox.ToString());
            toString.Append("DashboardUrl: ").AppendLine(DashboardUrl);
            toString.Append("AppstoreCurrency: ").AppendLine(AppstoreCurrency);
            return toString.ToString();
        }
    }
}
