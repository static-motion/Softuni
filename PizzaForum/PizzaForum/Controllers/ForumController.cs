using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.BindingModels;
using PizzaForum.Models;
using PizzaForum.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaForum.Controllers
{
    class ForumController : Controller
    {
        private ForumService service;
        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel rubm)
        {
            if (!service.IsViewModelValid(rubm))
            {
                this.Redirect(response, "/forum/register");
                return null;
            }
            User user = service.GetUserFromBind(rubm);
            service.RegisterUser(user);

            this.Redirect(response, "/forum/login");
            return null;
        }
    }
}
