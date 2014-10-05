namespace TictailSharp.Api.Methods
{
    public interface IGet<out TResource>
    {
        TResource Get();
        TResource DeserializeGet(string value);
    }
}
