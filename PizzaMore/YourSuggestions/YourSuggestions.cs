using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using PizzaMore.Utility;

namespace YourSuggestions
{
    class YourSuggestions
    {
        private static Header Header = new Header();

        private static Session Session;
        static void Main()
        {
            Session = WebUtil.GetSession();
            if (Session != null)
            {
                if (WebUtil.IsGet())
                {
                    ShowPage();
                }
                else
                {
                    var delete = WebUtil.RetrievePostParameters();
                    PizzaMoreContext deleteContext = new PizzaMoreContext();
                    using (deleteContext)
                    {
                        var pizza = deleteContext.Pizzas.Find(int.Parse(delete["pizzaId"]));
                        deleteContext.Pizzas.Remove(pizza);
                        deleteContext.SaveChanges();
                    }
                    ShowPage();
                }
            }
            else
            {
                WebUtil.PageNotAllowed();
            }
        }

        private static void ShowPage()
        {
            try
            {
                Header.Print();
                WebUtil.PrintFileContent("../htdocs/pm/yoursuggestions-top.html");
                PrintListOfSuggestedItems();
                WebUtil.PrintFileContent("../htdocs/pm/yoursuggestions-bottom.html");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }

        private static void PrintListOfSuggestedItems()
        {
            var userId = Session.UserId;
            PizzaMoreContext suggestedItems = new PizzaMoreContext();
            List<Pizza> suggestions = new List<Pizza>();
            using (suggestedItems)
            {
                suggestions = (from p in suggestedItems.Pizzas
                                 where p.OwnerId == userId
                                    select p).ToList();
            }
            Console.WriteLine("<ul>");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }
            Console.WriteLine("</ul>");

        }
    }
}
