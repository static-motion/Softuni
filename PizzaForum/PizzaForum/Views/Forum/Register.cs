using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace PizzaForum.Views.Forum
{
    class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + "nav-not-logged.html");
            string register = File.ReadAllText(Constants.ContentPath + "register.html");
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder pageContentBuilder = new StringBuilder();
            pageContentBuilder.Append(header);
            pageContentBuilder.Append(navigation);
            pageContentBuilder.Append(register);
            pageContentBuilder.Append(footer);

            return pageContentBuilder.ToString();
        }
    }
}
