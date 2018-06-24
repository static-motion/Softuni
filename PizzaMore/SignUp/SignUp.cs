using System.Linq;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using PizzaMore.Utility;

namespace SignUp
{
    class SignUp
    {
        private static Header Header = new Header();

        static void Main()
        {
            
            if (WebUtil.IsGet())
            {                
                ShowPage();
            }
            else
            {
                var userCredidentials = WebUtil.RetrievePostParameters();
                var email = userCredidentials["email"];
                var password =  PasswordHasher.Hash(userCredidentials["password"]);
                PizzaMoreContext addUser = new PizzaMoreContext();
                using (addUser)
                {
                    var exists = (from e in addUser.Users
                        where e.Email == email
                        select e).Any();
                    if (!exists)
                    {
                        addUser.Users.Add(new User(email, password));
                        addUser.SaveChanges();
                    }                 
                }
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            Header.Print();            
            WebUtil.PrintFileContent("../htdocs/pm/signup.html");
        }
    }
}
