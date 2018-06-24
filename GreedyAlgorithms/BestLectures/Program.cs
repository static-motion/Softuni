using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BestLectures
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Regex.Match(Console.ReadLine(), @"\d+").Groups[0].Value);
            List<Lecture> lectures = new List<Lecture>();
            ParseInput(count, lectures);
            lectures.Sort();
            Lecture current = lectures.First();
            List<Lecture> schedule = new List<Lecture>();
            schedule.Add(current);
            foreach (var lecture in lectures)
            {
                if (current.End <= lecture.Start)
                {
                    current = lecture;
                    schedule.Add(current);
                }
            }
            PrintLectures(schedule);
        }

        private static void ParseInput(int count, List<Lecture> lectures)
        {
            for (int i = 0; i < count; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), @"(\w+):\s(\d+)\s\D+\s(\d+)");
                string name = match.Groups[1].Value;
                int start = int.Parse(match.Groups[2].Value);
                int end = int.Parse(match.Groups[3].Value);
                lectures.Add(new Lecture(name, start, end));
            }
        }

        private static void PrintLectures(List<Lecture> schedule)
        {
            Console.WriteLine($"Lectures ({schedule.Count}):");
            foreach (var lecture in schedule)
            {
                Console.WriteLine(lecture.ToString());
            }
        }

        class Lecture : IComparable<Lecture>
        {
            private string Name { get; }
            public int Start { get; }
            public int End { get; }

            public Lecture(string name, int start, int end)
            {
                this.Name = name;
                this.Start = start;
                this.End = end;
            }

            public int CompareTo(Lecture other)
            {
                return End.CompareTo(other.End);
            }

            public override string ToString()
            {
                return $"{Start}-{End} -> {Name}";
            }
        }
    }
}
