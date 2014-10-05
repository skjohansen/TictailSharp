namespace TictailSharp.Api.Methods
{
    public interface IDelete<in TResource>
    {
        bool Delete(TResource value);
    }
}
