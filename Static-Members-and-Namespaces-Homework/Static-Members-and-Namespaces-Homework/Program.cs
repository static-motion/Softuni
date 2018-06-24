using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Members_and_Namespaces_Homework
{
    class Program
    {
        static void Main()
        {
            Point3D pointA = new Point3D(3, 4, 5);
            Point3D pointB = new Point3D(1, 3, 12);
            Console.WriteLine(Point3D.StartingPoint);
            double distance = DistanceCalculator.CalculateDistance(pointA.Point, pointB.Point);
            Console.WriteLine(distance);
        }
    }
}