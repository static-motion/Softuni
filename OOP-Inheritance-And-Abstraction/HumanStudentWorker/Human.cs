using System;
using System.Collections.Generic;

namespace HumanStudentWorker
{
    abstract class Human
    {
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
