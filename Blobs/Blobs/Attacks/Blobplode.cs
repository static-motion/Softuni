using Blobs.Interfaces;

namespace Blobs.Attacks
{
    public class Blobplode : Attack
    {
        private const double damageModifier = 2;
        private const double healthModifier = 0.5;

        public Blobplode() : base(damageModifier, healthModifier)
        {
        }
        
    }
}