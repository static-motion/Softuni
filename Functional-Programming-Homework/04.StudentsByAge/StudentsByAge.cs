using System;
using System.Linq;
using _01.ClassStudent;

namespace _04.StudentsByAge
{
    class StudentsByAge
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var studentsByAge = from student in students
                                where student.Age >= 18 && student.Age <= 24
                                select new { student.FirstName, student.LastName, student.Age }; 
            foreach(var student in studentsByAge)
            {
                Console.WriteLine("Student: {0} {1}\nAge: {2}",
                student.FirstName, student.LastName, student.Age);
                Console.WriteLine();
            }
        }
    }
}
