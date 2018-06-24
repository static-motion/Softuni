using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProcessorScheduling
{
    class Program
    {
        static void Main()
        {
            List<Task> schedule = new List<Task>();
            List<Task> tasks = new List<Task>();
            int taskCount = int.Parse(Regex.Match(Console.ReadLine(), @"\d+").Groups[0].Value);
            int taskOrder = 1;
            int cycle = 1;
            for (int i = 0; i < taskCount; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), @"(\d+)\s\D+\s(\d+)");
                int value = int.Parse(match.Groups[1].Value);
                int deadline = int.Parse(match.Groups[2].Value);
                double weight = (double) value / deadline;
                Task task = new Task(value, deadline, taskOrder++, weight);
                tasks.Add(task);
            }
            tasks = tasks.OrderByDescending(x => x.Value).ThenByDescending(x => x.Weight).ToList();
            foreach (var task in tasks)
            {
                if (task.Deadline - cycle >= 0)
                {
                    schedule.Add(task);
                    cycle++;
                }
            }
            schedule.Sort();
            Console.WriteLine(string.Join(" -> ", schedule));
        }
    }

    class Task : IComparable<Task>
    {
        public int Value { get; set; }
        public int Deadline { get; set; }
        public int TaskOrder { get; set; }
        public double Weight { get; set; }

        public Task(int value, int deadline, int taskOrder, double weight)
        {
            this.Value = value;
            this.Deadline = deadline;
            this.TaskOrder = taskOrder;
            this.Weight = weight;
        }

        public int CompareTo(Task other)
        {
            int result  = this.Deadline.CompareTo(other.Deadline);

            if (result == 0)
                result = other.Value.CompareTo(this.Value);

            return result;
        }

        public override string ToString()
        {
            return this.TaskOrder.ToString();
        }
    }
}
