using System;

namespace AreasInAMaze
{
    class Area: IComparable<Area>
    {
        public int Size;
        public int StartRow;
        public int StartCol;

        public Area(int areaNubmer, int startRow, int startCol, int size = 0)
        {
            this.Size = size;
            this.StartRow = startRow;
            this.StartCol = startCol;
        }
        public int CompareTo(Area other)
        {
            int result = other.Size.CompareTo(this.Size);
            if (result == 0)
            {
                result = this.StartRow.CompareTo(other.StartRow);
            }
            if (result == 0)
            {
                result = this.StartCol.CompareTo(other.StartCol);
            }
            return result;
        }

        public string ToString(int areaNumber)
        {
            return $"Area #{areaNumber} at ({StartRow}, {StartCol}), size: {Size}";
        }
    }
}
