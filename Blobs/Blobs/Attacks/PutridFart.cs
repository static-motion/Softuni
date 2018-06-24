using Blobs.Interfaces;

namespace Blobs.Attacks
{
    public class PutridFart : Attack
    {
        private const double damageModifier = 1;
        private const double healthModifier = 1;

        public PutridFart() : base(damageModifier, healthModifier)
        {
        }
    }
}