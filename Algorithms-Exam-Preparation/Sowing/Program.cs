using System;
using System.Diagnostics;
using System.Text;

namespace Sowing
{
    class Program
    {
        private static string[] field;
        private static bool[] planted;
        private static StringBuilder variations = new StringBuilder();
        static void Main()
        {
            int chukundurSeeds = int.Parse(Console.ReadLine());
            field = Console.ReadLine().Split(' ');
            planted = new bool[field.Length];
            PlantChukundurs(0, chukundurSeeds);
            Console.Write(variations);
        }

        private static void PlantChukundurs(int start, int seedsLeft)
        {
            if (seedsLeft == 0)
            {
                AppendResult();
                return;
            }
            for (int i = start; i < field.Length; i++)
            {
                if (CanPlantChukundur(i))
                {
                    planted[i] = true;
                    PlantChukundurs(i + 2, seedsLeft - 1);
                    planted[i] = false;
                }
            }
        }

        private static void AppendResult()
        {
            for (int i = 0; i < field.Length; i++)
            {
                variations.Append(planted[i] ? "." : field[i]);
            }
            variations.Append("\n");
        }

        private static bool CanPlantChukundur(int start)
        {
            bool isSuitable = field[start] == "1";
            if (start == 0)
            {
                return !planted[start + 1] && isSuitable;
            }
            if (start == field.Length - 1)
            {
                return !planted[start - 1] && isSuitable;
            }
            return !planted[start + 1] && !planted[start - 1] && isSuitable;
        }
    }
}
