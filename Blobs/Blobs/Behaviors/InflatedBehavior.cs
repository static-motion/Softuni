namespace Blobs.Behaviors
{
    public class InflatedBehavior : Behavior
    {
        private const int damageEffect = 0;
        public const int healthEffect = -10;
        private const BehaviorType aggressiveBehavior = BehaviorType.Aggressive;

        public InflatedBehavior() : base(damageEffect, healthEffect, aggressiveBehavior)
        {
        }
    }
}