using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Threading;

class ChatLogger
{
    static void Main()
    {
        
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        DateTime currentDate = DateTime.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(new[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
        var messages = new Dictionary<string, DateTime>();
        while(input[0] != "END")
        {
            messages.Add(input[0], DateTime.Parse(input[1]));
            input = Console.ReadLine().Split(new[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
        }

        var orderedMessages = from message in messages
                              orderby message.Value
                              select message;

        DateTime lastMessage = orderedMessages.Last().Value;
        TimeSpan difference = currentDate - lastMessage;
        string lastActive;

        if (lastMessage.Date.AddDays(1) == currentDate.Date)
        {
            lastActive = "yesterday";
        }
        else if (difference.Minutes < 1 && difference.Days < 1 && difference.Hours < 1)
        {
            lastActive = "a few moments ago";
        }
        else if(difference.Hours < 1 && difference.Days < 1)
        {
            lastActive = String.Format("{0} minute(s) ago", difference.Minutes);
        }
        else if (currentDate.Date == lastMessage.Date && currentDate.Month == lastMessage.Month)
        {
            lastActive = String.Format("{0} hour(s) ago", difference.Hours);
        }      
        else
        {
            lastActive = lastMessage.ToString("dd-MM-yyyy");
        }
        foreach(var message in orderedMessages)
        {
            Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(message.Key));
        }
        Console.WriteLine("<p>Last active: <time>{0}</time></p>", lastActive);
    }
}

