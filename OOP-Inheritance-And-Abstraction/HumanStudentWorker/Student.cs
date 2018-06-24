namespace HumanStudentWorker
{
    class Student : Human
    {
        public Student(string firstName, string lastName, string facultyNumber) : base (firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        public string FacultyNumber { get; private set; }
    }
}
