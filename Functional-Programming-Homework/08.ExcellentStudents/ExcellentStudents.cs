using System;
using System.Linq;
using _01.ClassStudent;

namespace _08.ExcellentStudents
{
    class ExcellentStudents
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var excellentStudents = from student in students
                                    where student.Marks.Contains(6)
                                    select student;

            foreach (var student in excellentStudents)
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
