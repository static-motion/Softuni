namespace Blobs.Interfaces
{
    public interface IBlobFactory
    {
        IBlob CreateBlob(string[] inputString);
    }
}