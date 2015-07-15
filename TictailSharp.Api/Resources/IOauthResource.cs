using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Oauth;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Oauth repository interface
    /// </summary>
    public interface IOauthResource : IPost<Oauth, Token>
    {
    }
}
