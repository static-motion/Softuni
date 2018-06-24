using System;
using Blobs.Behaviors;
using Blobs.Core.Factories;
using Blobs.Interfaces;

namespace Blobs.Core
{
    public class Engine : IEngine
    {
        private readonly IBlobFactory blobFactory;
        private readonly IBlobsData blobsData;
        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;

        public Engine(IBlobFactory blobFactory, IBlobsData blobsData, IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.blobFactory = blobFactory;
            this.blobsData = blobsData;
            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = inputReader.ReadLine().Split(' ');
                ExecuteCommand(input);
                UpdateBehavior();
            }
        }

        private void UpdateBehavior()
        {
            foreach (Blob blob in blobsData.Blobs)
            {
                if (blob.BehaviorHasBeenActivated)
                {
                    switch (blob.behavior)
                    {
                        case BehaviorType.Aggressive:
                            if (blob.currentDamage > blob.Damage)
                            {
                                blob.currentDamage += AggressiveBehavior.damageEffect;
                            }
                            break;
                        case BehaviorType.Inflated:
                            blob.Health += InflatedBehavior.healthEffect;
                            break;
                    }
                }
            }
        }

        private void ExecuteCommand(string[] inputCommands)
        {
            switch (inputCommands[0])
            {
                case "create":
                    ExecuteCreateCommand(inputCommands);
                    break;
                case "attack":
                    FindAttackerAndAttacked(inputCommands);
                    break;
                case "status":
                    ExecuteStatusCommand();
                    break;
                case "pass":
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;

            }
        }

        private void ExecuteStatusCommand()
        {
            foreach (Blob blob in blobsData.Blobs)
            {
                if (blob.Health > 0)
                {
                    outputWriter.Write(string.Format("Blob {0}: {1} HP, {2} Damage", blob.Name, blob.Health, blob.currentDamage));
                }
                else
                {
                    outputWriter.Write(string.Format("Blob {0} KILLED", blob.Name));
                }
            }
        }

        private void FindAttackerAndAttacked(string[] inputCommands)
        {
            string attacker = inputCommands[1];
            string attacked = inputCommands[2];

            foreach (Blob potentialAttacker in blobsData.Blobs)
            {
                if (potentialAttacker.Name == attacker)
                {
                    foreach (Blob potentialAttacked in blobsData.Blobs)
                    {
                        if (potentialAttacked.Name == attacked)
                        {
                            potentialAttacked.AttackBlob(potentialAttacker);
                            return;
                        }
                    }
                }
            }
        }

        private void ExecuteCreateCommand(string[] inputCommands)
        {
            IBlob blob = blobFactory.CreateBlob(inputCommands);
            this.blobsData.AddBlob(blob);
        }
    }
}