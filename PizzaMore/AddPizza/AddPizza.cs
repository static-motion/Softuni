using PizzaMore.Data;
using PizzaMore.Data.Models;
using PizzaMore.Utility;

namespace AddPizza
{
    class AddPizza
    {
        private static Header Header = new Header();

        private static Session Session;
        static void Main()
        {
            Session = WebUtil.GetSession();
            Header.Print();
            if (Session != null)
            {               
                if (WebUtil.IsGet())
                {
                    ShowPage();
                }
                else
                {
                    var pizzaInfo = WebUtil.RetrievePostParameters();
                    var pizzaName = pizzaInfo["title"];
                    var pizzaRecipe = pizzaInfo["recipe"];
                    var pizzaUrl = pizzaInfo["url"];

                    PizzaMoreContext addPizzaContext = new PizzaMoreContext();
                    using (addPizzaContext)
                    {
                        Pizza pizza = new Pizza()
                        {
                            Title = pizzaName,
                            Recipe = pizzaRecipe,
                            ImageUrl = pizzaUrl,
                            OwnerId = Session.UserId,
                            DownVotes = 0,
                            UpVotes = 0
                        };
                        addPizzaContext.Pizzas.Add(pizza);
                        addPizzaContext.SaveChanges();
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
            WebUtil.PrintFileContent("../htdocs/pm/addpizza.html");
        }
    }
}
