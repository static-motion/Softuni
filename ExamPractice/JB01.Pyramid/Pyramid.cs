using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Pyramid
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[][] pyramid = new int[size][];
        List<int> numbers = new List<int>();
        for (int i = 0; i < size; i++)
        {
            numbers = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            numbers.Sort();
            pyramid[i] = new int[numbers.Count];
            for (int cols = 0; cols < numbers.Count; cols++)
            {               
                pyramid[i][cols] = numbers[cols];
            }         
        }
        List<int> sequence = new List<int>();
        int currentNum = pyramid[0][0];
        bool foundBiggerNum = false;
        sequence.Add(currentNum);
        for (int row = 1; row < size; row++)
        {
            for (int col = 0; col < pyramid[row].Length; col++)
            {
                if(currentNum < pyramid[row][col])
                {
                    currentNum = pyramid[row][col];
                    sequence.Add(currentNum);
                    foundBiggerNum = true;
                    break;
                }
                else
                {
                    foundBiggerNum = false;
                }
            }
            if(foundBiggerNum == false)
            {
                currentNum++;
            }
        }
        Console.WriteLine(string.Join(", ", sequence));
    }
}

