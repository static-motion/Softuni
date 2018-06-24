using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace PizzaForum.Views.Forum
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbar = File.ReadAllText(Constants.ContentPath + "nav-not-logged.html");
            string login = File.ReadAllText(Constants.ContentPath + "login.html");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder pageContentBuilder = new StringBuilder();

            pageContentBuilder.Append(header);
            pageContentBuilder.Append(navbar);
            pageContentBuilder.Append(login);
            pageContentBuilder.Append(footer);

            return pageContentBuilder.ToString();
        }
    }
}