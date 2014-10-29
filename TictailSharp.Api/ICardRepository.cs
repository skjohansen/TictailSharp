using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Card;

namespace TictailSharp.Api
{
    /// <summary>
    /// Card repository interface
    /// </summary>
    public interface ICardRepository : IStore, IPost<Card, string>, IGetSpecific<Card>
    {
    }
}
