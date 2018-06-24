using System;
using System.Linq;
using _01.ClassStudent;

namespace _05.SortStudents
{
    class SortStudents
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var orderedStudents = students
                .OrderByDescending(a => a.FirstName)
                .ThenByDescending(b => b.LastName);

            foreach (var student in orderedStudents)
            {
                string marks = String.Join(", ", student.Marks);
                Console.WriteLine("Student: {0} {1},\nAge: {2} \nFactualy number: {3}, \nPhone: {4}, \nEmail: {5}, \nMarks: ({6}), \nGroup number: {7}",
                student.FirstName, student.LastName, student.Age, student.FacultyNumber, student.Phone, student.Email,
                marks, student.GroupNumber);
                Console.WriteLine();
            }
        }
    }
}
