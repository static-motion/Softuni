namespace Blobs.Interfaces
{
    public interface IBehavior
    {
        BehaviorType BehaviorType { get; }
        int HealthEffect { get; }
        int DamageEffect { get; }
    }
}