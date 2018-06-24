using System;
using System.Collections.Generic;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using PizzaMore.Utility;

namespace Home
{
    class Home
    {
        private static IDictionary<string, string> RequestParameters;

        private static Session Session;

        private static Header Header = new Header();

        private static string Language;

        
        static void Main()
        {
            
            AddDefaultCookie();
            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }
            ShowPage();
        }
        static void AddDefaultCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            }
        }

        static void ShowPage()
        {
            Header.Print();
            if (Language == "EN")
            {
                ServeHtmlEn();
            }
            else
            {
                ServeHtmlDe();
            }
        }

        static void ServeHtmlEn()
        {
            string path = "../htdocs/pm/home.html";
            WebUtil.PrintFileContent(path);
        }

        static void ServeHtmlDe()
        {
            string path = "../htdocs/pm/home-de.html";
            WebUtil.PrintFileContent(path);
        }

        private static void TryLogOut()
        {
            if(RequestParameters.ContainsKey("logout"))
            {
                if (RequestParameters["logout"] == "true")
                {
                    Session = WebUtil.GetSession();
                    PizzaMoreContext sessionContext = new PizzaMoreContext();
                    
                    Logger.Log(Session.Id);
                    using (sessionContext)
                    {
                        var session = sessionContext.Sessions.Find(Session.Id);         
                        sessionContext.Sessions.Remove(session);
                        sessionContext.SaveChanges();
                    }
                }
            }          
        }
    }
}
