using System;
using Blobs.Interfaces;

namespace Blobs.Core.Factories
{
    public class BlobFactory : IBlobFactory
    {
        private readonly AttackFactory attackParser = new AttackFactory();

        public IBlob CreateBlob(string[] inputString)
        {
            string name = inputString[1];
            int health = int.Parse(inputString[2]);
            int damage = int.Parse(inputString[3]);
            BehaviorType behavior = (BehaviorType) Enum.Parse(typeof (BehaviorType), inputString[4]);
            IAttack attackType = attackParser.ParseAttack(inputString[5]);
            Blob blob = new Blob(name, health, damage, behavior, attackType);
            return blob;
        }
    }
}