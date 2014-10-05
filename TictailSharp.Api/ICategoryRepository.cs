using TictailSharp.Api.Methods;
using TictailSharp.Api.Model;

namespace TictailSharp.Api
{
    public interface ICategoryRepository : IStore, IGetRange<Category>
    {
    }
}
