using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine().Split(' ');
            int cellsBombarded = 0;
            long cubeParticles = 0;
            int cubeTotalCells = size*size*size;
            while (coordinates[0] != "Analyze")
            {
                long x = long.Parse(coordinates[0]);
                long y = long.Parse(coordinates[1]);
                long z = long.Parse(coordinates[2]);
                long particles = long.Parse(coordinates[3]);
                if (CheckIfInsideCube(size, x, y, z) && particles != 0)
                {
                    cellsBombarded++;
                    cubeParticles += particles;
                }
                coordinates = Console.ReadLine().Split(' ');
            }
            Console.WriteLine(cubeParticles);
            Console.WriteLine(cubeTotalCells - cellsBombarded);
        }


        static bool CheckIfInsideCube(int size, long x, long y, long z)
        {
            bool xIsInside = x >= 0 && x < size;
            bool yIsInside = y >= 0 && y < size;
            bool zIsInside = z >= 0 && z < size;

            if (xIsInside && yIsInside && zIsInside)
            {
                return true;
            }
            return false;
        }
    }
}
