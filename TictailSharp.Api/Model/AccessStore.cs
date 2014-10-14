using System.Globalization;
using System.Text;

namespace TictailSharp.Api.Model
{
    public class AccessStore : BaseStore
    {
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Name: ").AppendLine(Name);
            toString.Append("ShortDescription: ").AppendLine(ShortDescription);
            toString.Append("Followers: ").AppendLine(NumberOfFollowers.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Vat: ").AppendLine(Vat.ToString());
            toString.Append("Language: ").AppendLine(Language);
            toString.Append("Country: ").AppendLine(Country);
            if (Logotypes != null && Logotypes.Count > 0)
            {
                foreach (var logotype in Logotypes)
                {
                    toString.Append("Logotype: ").AppendLine(logotype.ToString());
                }

            }
            // TODO:Wallpapers
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("Url: ").AppendLine(Url);
            if (CreatedAt.HasValue)
            {
                toString.Append("CreatedAt: ").AppendLine(CreatedAt.Value.ToString());
            }
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString());
            }
            toString.Append("ContactEmail: ").AppendLine(ContactEmail);
            toString.Append("StorekeeperEmail: ").AppendLine(StorekeeperEmail);
            toString.Append("Sandbox: ").AppendLine(Sandbox.ToString());
            toString.Append("DashboardUrl: ").AppendLine(DashboardUrl);
            return toString.ToString();
        }
    }
}
