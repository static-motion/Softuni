using System;
using System.Linq;
using _01.ClassStudent;

namespace _07.FilterByPhone
{
    class FilterByPhone
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var filteredPhones = from student in students
                                 where student.Phone.Contains("02")
                                 || student.Phone.Contains("+3592")
                                 || student.Phone.Contains("+359 2")
                                 select student;

            foreach (var student in filteredPhones)
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
