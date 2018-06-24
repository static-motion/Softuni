using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Defining_Classes_Homework
{
    class Persons
    {
        private string name;
        private int age;
        private string email;

        public Persons(string name, int age)
        {
            Name = name;
            this.Age = age;
        }
        public Persons(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception("Invalid name");
                }
            }          
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value > 0 && value <= 100)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Invalid age");
                }
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (value.Contains("@"))
                {
                    this.email = value;
                }
                else
                {
                    throw new Exception("Invalid email");
                }
            }
        }
        public override string ToString()
        {
            string personInformation = string.Format("Name: {0}, Age: {1}", name, age);
            if(email != null)
            {
                personInformation += string.Format(", Email {0}", email);
            }       
            return personInformation;
        }
    }
}
