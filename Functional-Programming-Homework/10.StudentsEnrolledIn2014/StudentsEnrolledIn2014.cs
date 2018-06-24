using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.ClassStudent;

namespace _10.StudentsEnrolledIn2014
{
    class StudentsEnrolledIn2014
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var studentsEnrolledIn2014 = from student in students
                                         where student.FacultyNumber % 100 == 14
                                         select student;

            foreach (var student in studentsEnrolledIn2014)
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
