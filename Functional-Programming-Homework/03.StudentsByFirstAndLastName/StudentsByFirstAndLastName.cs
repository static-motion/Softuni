﻿using System;
using System.Linq;
using _01.ClassStudent;

namespace _03.StudentsByFirstAndLastName
{
    class StudentsByFirstAndLastName
    {
        static void Main()
        {
            var students = StudentsInformation.StudentInfo();
            var firstAndLastNameStudents = from st in students
                                           where st.FirstName.CompareTo(st.LastName) < 0
                                           select st;

            foreach (var student in firstAndLastNameStudents)
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
