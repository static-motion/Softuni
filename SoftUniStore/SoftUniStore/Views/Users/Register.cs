using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace SoftUniStore.Views.Users
{
    class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navbar = File.ReadAllText(Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.ContentPath + "register.html");
            string footer = File.ReadAllText(Constants.Footer);

            StringBuilder pageContentBuilder = new StringBuilder();

            pageContentBuilder.Append(header);
            pageContentBuilder.Append(navbar);
            pageContentBuilder.Append(register);
            pageContentBuilder.Append(footer);

            return pageContentBuilder.ToString();
        }
    }
}
