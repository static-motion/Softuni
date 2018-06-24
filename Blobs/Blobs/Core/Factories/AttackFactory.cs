using System;
using Blobs.Attacks;
using Blobs.Interfaces;

namespace Blobs.Core.Factories
{
    public class AttackFactory : IParseAttack
    {
        public IAttack ParseAttack(string attackType)
        {
            switch (attackType)
            {
                case"PutridFart":
                    return new PutridFart();
                case "Blobplode":
                    return new Blobplode();
                default:
                    throw new ArgumentException("Invalid attack command");
            }
        }
    }
}