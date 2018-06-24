using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PINValidation
{
    static void Main()
    {
        string name = Console.ReadLine();
        string gender = Console.ReadLine();
        string PIN = Console.ReadLine();

        if(PIN.Length != 10)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        try
        {
            ulong pinnum = ulong.Parse(PIN);
        }
        catch(SystemException)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        string currentGender;
        int year;
        int month;
        int date;
        int region;
        int checksum;
        try
        {
            year = int.Parse(PIN.Substring(0, 2));
            month = int.Parse(PIN.Substring(2, 2));
            date = int.Parse(PIN.Substring(4, 2));
            region = int.Parse(PIN[PIN.Length - 2].ToString());
            checksum = int.Parse(PIN[PIN.Length - 1].ToString());
        }
        catch(SystemException)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        if (month > 52)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        if(region % 2 == 0)
        {
            currentGender = "male";
        }
        else
        {
            currentGender = "female";
        }

        if (currentGender != gender)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        List<int> numbers = new List<int>()
        {
            2,4,8,5,10,9,7,3,6
        };

        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(PIN[i].ToString()) * numbers[i];
        }

        sum %= 11;
        sum %= 10;
        if (sum != checksum)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        List<string> firstAndLastName = name.Split(' ').ToList();
        if (firstAndLastName.Count != 2
            || firstAndLastName[0][0] < 'A'
            || firstAndLastName[0][0] > 'Z'
            || firstAndLastName[1][0] < 'A'
            || firstAndLastName[1][0] > 'Z')
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        name = String.Format("\"name\":\"{0}\"", name);
        gender = String.Format("\"gender\":\"{0}\"", gender);
        PIN = String.Format("\"pin\":\"{0}\"", PIN);
        Console.WriteLine("{" + name + "," + gender + "," + PIN + "}");

    }
}

