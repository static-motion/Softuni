using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Members_and_Namespaces_Homework
{
    static class DistanceCalculator
    {
        public static double CalculateDistance(int[] pointA, int[] pointB)
        {
            double distance = Math.Sqrt(Math.Pow(pointA[0] - pointB[0], 2) + Math.Pow(pointB[1] - pointA[1], 2) + Math.Pow(pointB[2] - pointA[2], 2));
            return distance;
        }
    }
}
