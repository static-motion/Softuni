using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ClassStudent;

namespace _09.WeakStudents
{
    class WeakStudents
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var weakStudents = from student in students
                               where student.Marks.Count(a => a == 2) == 2
                               select student;

            foreach (var student in weakStudents)
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
