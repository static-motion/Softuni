namespace Blobs.Interfaces
{
    public interface IBlob : IAttacker, IKIllable
    {
        string Name { get; } 
    }
}