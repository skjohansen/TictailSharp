using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// Your theme is what makes up your digital store, its beauty is what'll sway customers your way. The Theme endpoint provides easy access to the HTML code with the mustache tags unrendered, leaving you with the choice of what to do. Use it to validate or modify the theme, its up to you - play to your hearts content!
    /// </summary>
    public class Theme
    {

        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The theme's markup, HTML containing unrendered mustache tags. This is the code as seen in the Theme Editor
        /// </summary>
        [JsonProperty(PropertyName = "markup")]
        public string Markup { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Markup: ").AppendLine(Markup);
            return toString.ToString();
        }
    }
}
