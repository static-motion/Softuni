using System.Collections.Generic;

namespace _01.ClassStudent
{
    public class StudentsInformation
    {
        public static List<Student> StudentInfo()
        {
            var students = new List<Student>()
                {
                new Student("William", "Alexander", 21, 452514, "02 223 458", "william_alex@abv.bg",new List<int> {4, 5, 4, 6 }, 1),
                new Student("Ashley", "Williams", 19, 456515, "02 153 246", "a.williams@gmail.com",new List<int> {6, 5, 6, 6 }, 1),
                new Student("Nathan", "Drake", 20, 783114, "02 748 127", "uncharted@yahoo.com",new List<int> {2, 3, 4, 2 }, 2),
                new Student("Ajay", "Ghale", 22, 647313, "0894123548", "far_cry@gmail.com",new List<int> {4, 5, 5, 6 }, 2),
                new Student("Jason", "Brody", 21, 748315, "02 324 562", "j_brody3@abv.bg",new List<int> {4, 4, 4, 5 }, 2),
                new Student("Miranda", "Lawson", 25, 148510, "02 129 558", "miranda.lawson@cerberus.com",new List<int> {6, 6, 6, 6 }, 3),
                new Student("Nik", "Roos", 29, 374809, "+3592 457 689", "nikroos@noisia.nl",new List<int> {4, 5, 4, 6 }, 3),
                new Student("Oliver", "Cash", 27, 439410, "+359889457832", "far_too_loud@gmail.com",new List<int> {6, 4, 4, 5 }, 3)
            };
            return students;   
        }
    }
}
