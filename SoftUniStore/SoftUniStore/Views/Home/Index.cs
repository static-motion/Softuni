using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Views.Home
{
    class Index : IRenderable<HomeViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navbar = File.ReadAllText(Constants.NavLogged);
            string home = string.Format(File.ReadAllText(Constants.ContentPath + "home.html"), Model);
            string footer = File.ReadAllText(Constants.Footer);

            StringBuilder pageContentBuilder = new StringBuilder();

            pageContentBuilder.Append(header);
            pageContentBuilder.Append(navbar);
            pageContentBuilder.Append(home);
            
            pageContentBuilder.Append(footer);

            return pageContentBuilder.ToString();
        }

        public HomeViewModel Model { get; set; }
    }
}
