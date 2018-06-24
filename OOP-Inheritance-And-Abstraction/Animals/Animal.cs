using System;

namespace Animals
{
    public abstract class Animal : ISoundProducible
    {
        private string name;
        private uint age;
        private string gender;

        public Animal(string name, uint age, string gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public uint Age { get; private set; }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null, empty or whitespace");
                }
                this.name = value;
            }
        }  
        public string Gender
        {
            get { return this.gender; }
            protected set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gender cannot be null, empty or whitespace");
                }
                if(value.ToLower() != "male" && value.ToLower() != "female")
                {
                    throw new ArgumentException("Gender can be either male or female");
                }
                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
