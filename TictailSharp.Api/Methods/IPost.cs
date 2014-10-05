namespace TictailSharp.Api.Methods
{
    public interface IPost<in TResource>
    {
        string Post(TResource value);
    }
}
