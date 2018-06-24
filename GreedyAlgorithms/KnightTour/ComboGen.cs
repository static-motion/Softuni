//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KnightTour
//{
//    class ComboGen
//    {
        
//        private static int[,] vector;
//        private static bool[] used;

//        static void Generate()
//        {
//            int length = int.Parse(Console.ReadLine());
//            vector = new int[8, 2];
//            used = new bool[8];
//            Gen(length);
//        }

//        private static void Gen(int length, int index = 0)
//        {
//            if (index >= length)
//            {
//            }
//            else
//            {
//                for (int i = 0; i < 8; i++)
//                {
//                    if (!used[i])
//                    {
//                        used[i] = true;
//                        for (int j = 0; j < 2; j++)
//                        {
//                            vector[index, j] = elements[i, j];
//                        }
//                        Gen(length, index + 1);
//                        used[i] = false;
//                    }
//                }
//            }
//        }

//        private static void Print()
//        {
//            Console.WriteLine(string.Join(" ", vector));
//        }
//    }
//}

