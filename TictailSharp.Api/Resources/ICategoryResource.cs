using TictailSharp.Api.Methods;
using TictailSharp.Api.Model.Category;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Category repository interface
    /// </summary>
    public interface ICategoryResource : IStore, IGetRange<Category>
    {
    }
}
