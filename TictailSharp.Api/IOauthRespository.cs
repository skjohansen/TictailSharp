using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Oauth;

namespace TictailSharp.Api
{
    /// <summary>
    /// Oauth repository interface
    /// </summary>
    public interface IOauthRespository : IPost<Oauth, Token>
    {
    }
}
