using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPClassExercise
{
    public class Dog
    {
        private string name;

        private string breed { get; set; }

        public Dog() : this(null, null)
        {
        }

        public Dog(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
        }
    }
}
