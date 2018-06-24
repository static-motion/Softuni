namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        
        static void Main()
        {
            List<Human> people = new List<Human>();
            List<Student> students = new List<Student>()
            {
                new Student("Nathan", "Drake", "000023ND"),
                new Student("Ezio", "Auditore","000074EA"),
                new Student("Lara", "Croft", "000059LC"),
                new Student("Triss", "Merigold", "000251TM"),
                new Student("Michael", "Westen", "xxxxxxxx"),
                new Student("Dexter", "Morgan", "000077DM"),
                new Student("Guybrush", "Threepwood", "000064MI"),
                new Student("Debra", "Morgan", "000136DM"),
                new Student("Edward", "Kenway", "000111EK"),
                new Student("John", "Shepard", "000001ME")
            };

            var orderedByFacultyNum = students.OrderBy(student => student.FacultyNumber);

            Console.WriteLine("[Students]");

            foreach (var student in orderedByFacultyNum)   
            {
                Console.WriteLine(student.FacultyNumber);
                people.Add(student);
            }

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Fiona", "Glenanne", 2000, 5),
                new Worker("Sam", "Axe", 1490, 1),
                new Worker("Michael", "De Santa", 14090, 3),
                new Worker("Trevor", "Phillips", 300, 5),
                new Worker("Cole", "Phelps", 700, 8),
                new Worker("Angel", "Batista", 1024, 8),
                new Worker("Gabe", "Newell", 83216371, 4),
                new Worker("November", "Terra", 29304, 14),
                new Worker("James", "Raynor", 0, 20),
                new Worker("John", "MacTavish", 6373, 24)
            };

            Console.WriteLine();
            Console.WriteLine("[Workers]");

            var orderedByMoneyPerHour = workers.OrderByDescending(worker => worker.MoneyPerHour());

            foreach (var worker in orderedByMoneyPerHour)
            {
                Console.WriteLine(worker.MoneyPerHour());
                people.Add(worker);
            }
            var orderedByName = people
                .OrderBy(person => person.FirstName)
                .ThenBy(person => person.LastName);
            Console.WriteLine();
            Console.WriteLine("[Ordered by first and last name]");
            foreach (var person in orderedByName)
            {
                Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
            }
        }
    }
}