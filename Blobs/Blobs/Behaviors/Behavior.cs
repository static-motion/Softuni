using Blobs.Interfaces;

namespace Blobs.Behaviors
{
    public class Behavior : IBehavior
    {
        protected Behavior(int damageEffect, int healthEffect, BehaviorType behaviorType)
        {
            this.DamageEffect = damageEffect;
            this.HealthEffect = healthEffect;
            this.BehaviorType = behaviorType;
        }

        public BehaviorType BehaviorType { get; }

        public int HealthEffect { get; }

        public int DamageEffect { get; }
    }
}