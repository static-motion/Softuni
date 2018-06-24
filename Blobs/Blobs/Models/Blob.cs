using Blobs.Interfaces;

namespace Blobs
{
    public class Blob : IBlob
    {
        private readonly IAttack attack;

        private int health;

        public Blob(string name, int health, int damage, BehaviorType behavior, IAttack attack)
        {
            this.attack = attack;
            this.behavior = behavior;
            Damage = damage;
            currentDamage = damage;
            Health = health;
            Name = name;
        }

        public int Damage { get; }

        public int Health
        {
            get { return this.health; }
            set { this.health = value < 0 ? 0 : value; }
        }

        public string Name { get; }

        public BehaviorType behavior { get; private set; }

        public bool BehaviorHasBeenActivated { get; private set; }

        public int currentDamage { get; set; }

        public void AttackBlob(Blob attacker)
        {
            if ((int) (attacker.currentDamage*attacker.attack.DamageModifier) > this.Health/2 && !BehaviorHasBeenActivated)
            {
                this.BehaviorHasBeenActivated = true;
                ActivateBehavior();
            }
            this.Health -= (int)(attacker.currentDamage * attacker.attack.DamageModifier);
            attacker.Health *= (int) attacker.attack.HealthModifier;
        }

        private void ActivateBehavior()
        {
            switch (behavior)
            {
                case BehaviorType.Aggressive:
                    this.currentDamage *= 2;
                    break;

                case BehaviorType.Inflated:
                    this.Health += 50;
                    break;
            }
        }
    }
}