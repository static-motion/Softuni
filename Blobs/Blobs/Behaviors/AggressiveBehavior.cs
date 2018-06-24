using Blobs.Interfaces;

namespace Blobs.Behaviors
{
    public class AggressiveBehavior : Behavior
    {
        public const int damageEffect = -5;
        private const int healthEffect = 0;
        private const BehaviorType aggressiveBehavior = BehaviorType.Aggressive;
        public AggressiveBehavior() : base(damageEffect, healthEffect, aggressiveBehavior)
        {
        }
    }
}