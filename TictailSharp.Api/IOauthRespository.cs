using TictailSharp.Api.Methods;
using TictailSharp.Api.Model;

namespace TictailSharp.Api
{
    public interface IOauthRespository : IPost<Oauth, Token>
    {
    }
}
