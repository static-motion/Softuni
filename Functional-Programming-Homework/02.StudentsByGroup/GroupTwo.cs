using System;
using System.Linq;
using _01.ClassStudent;

namespace _02.StudentsByGroup
{
    class GroupTwo
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var groupTwo = students
                .Where(a => a.GroupNumber == 2)
                .OrderBy (a => a.FirstName);
            foreach(var student in groupTwo)
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
