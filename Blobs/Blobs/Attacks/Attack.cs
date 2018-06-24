using Blobs.Interfaces;

namespace Blobs.Attacks
{
    public class Attack : IAttack
    {
        protected Attack(double damageModifier, double healthModifier)
        {
            HealthModifier = healthModifier;
            DamageModifier = damageModifier;
        }

        public double DamageModifier { get; protected set; }

        public double HealthModifier { get; protected set; }
    }
}