using System;
namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals =
            {
                new Cat("Pesho", 2, "Male"),
                new Tomcat("Gosho", 1),
                new Kitten("Lisa", 2),
                new Frog("Kerby", 20, "Male"),
                new Dog("Toshko", 3, "Female")
            };
            double averageAge = 0;
            foreach (var animal in animals)
            {
                averageAge += animal.Age;
            }
            averageAge /= animals.Length;
            Console.WriteLine(averageAge);
        }
    }
}
