using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Follower;

namespace TictailSharp.Api
{
    /// <summary>
    /// Follower repository interface
    /// </summary>
    public interface IFollowerRepository : IGetRange<Follower>, IStore, IPost<Follower, string>, IDelete<Follower>
    {
    }
}
