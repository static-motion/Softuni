using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Members_and_Namespaces_Homework
{
    class Point3D
    {
        private int[] point = new int[3];
        private static readonly int[] startingPoint = new int[] { 0, 0, 0 };
        public Point3D(int x, int y, int z)
        {
            this.point[0] = x;
            this.point[1] = y;
            this.point[2] = z;
        }
        public int[] Point
        {
            get { return this.point; }
        }
        public static string StartingPoint
        {
            get
            {
                return String.Join(", ", startingPoint);
            }
        }
        public override string ToString()
        {
            return String.Join(", ", point);
        }
    }
}
