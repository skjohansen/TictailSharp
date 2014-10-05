using TictailSharp.Api.Methods;
using TictailSharp.Api.Model;

namespace TictailSharp.Api
{
    public interface IFollowerRepository : IGetRange<Follower>, IStore, IPost<Follower>, IDelete<Follower>
    {
    }
}
