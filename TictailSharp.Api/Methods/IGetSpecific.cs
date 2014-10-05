namespace TictailSharp.Api.Methods
{
    public interface IGetSpecific<out TResource>
    {
        TResource Get(string idOrHref);
        TResource DeserializeGet(string value);
        TResource this[string idOrHref] { get; }
    }
}
