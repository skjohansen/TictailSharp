using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Follower;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Follower repository interface
    /// </summary>
    public interface IFollowerResource : IGetRange<Follower>, IStore, IPost<Follower, string>, IDelete<Follower>
    {
    }
}
