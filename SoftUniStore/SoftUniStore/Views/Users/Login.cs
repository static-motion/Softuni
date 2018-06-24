using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftUniStore.Views.Users
{
    class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navbar = File.ReadAllText(Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.ContentPath + "login.html");
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
