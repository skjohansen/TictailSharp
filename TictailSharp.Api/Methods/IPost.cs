namespace TictailSharp.Api.Methods
{
    public interface IPost<in TResource, out TReturn>
    {
        TReturn Post(TResource value);
    }
}
