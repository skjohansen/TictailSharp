using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Category;

namespace TictailSharp.Api
{
    /// <summary>
    /// Category repository interface
    /// </summary>
    public interface ICategoryRepository : IStore, IGetRange<Category>
    {
    }
}
