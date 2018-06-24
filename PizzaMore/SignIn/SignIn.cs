using System;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using PizzaMore.Utility;

namespace SignIn
{
    class SignIn
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
                var hashedPassword = PasswordHasher.Hash(userCredidentials["password"]);
                PizzaMoreContext databaseContext = new PizzaMoreContext();
                using (databaseContext)
                {
                    //Validate user credidentials
                    var validId = from user in databaseContext.Users
                                  where user.Email == email && user.Password == hashedPassword
                                  select user;
                    //Check if user is already logged in
                    var existingSession = (from session in databaseContext.Sessions
                                           where session.UserId == validId.FirstOrDefault().Id
                                           select session)
                                           .Any();
                    if (validId.Any() && !existingSession)
                    {
                        var userId = validId.First().Id;
                        Session userSession = new Session(userId);
                        userSession.User = validId.First();
                        userSession.Id = new Random().Next().ToString();
                        databaseContext.Sessions.Add(userSession);
                        Header.AddCookie(new Cookie("sid", userSession.Id));
                        databaseContext.SaveChanges();
                    }                
                    ShowPage();
                }
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../htdocs/pm/signin.html");
        }
    }
}
