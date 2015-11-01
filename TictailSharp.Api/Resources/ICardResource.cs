using System;
using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Card;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Card repository interface
    /// </summary>
    public interface ICardResource : IStore, IPost<PostCard, GetCard>, IGetSpecific<GetCard>
    {
    }
}
