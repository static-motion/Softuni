using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftUniStore.BindingModels;
using SoftUniStore.Models;
using SoftUniStore.Services;
using SoftUniStore.Utilities;

namespace SoftUniStore.Controllers
{
    class UsersController : Controller
    {
        private UserService service;

        public UsersController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.AuthenticateUser(session))
            {
                return this.View();
            }       
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpPost]
        public IActionResult Register(HttpSession session, HttpResponse response, RegisterUserBindingModel rubm)
        {
            if (AuthenticationManager.AuthenticateUser(session))
            {
                if (!this.service.IsRegisterModelValid(rubm))
                {
                    this.Redirect(response, "/users/register");
                    return null;
                }
                User user = this.service.GetUserFromRegisterBind(rubm);
                this.service.RegisterUser(user);
                this.Redirect(response, "/users/login");
                return null;
            }
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if(AuthenticationManager.AuthenticateUser(session))
                return this.View();

            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lumb)
        {
            if (AuthenticationManager.AuthenticateUser(session))
            {
                if (!service.IsLoginBindValid(lumb))
                {
                    this.Redirect(response, "/users/login");
                    return null;
                }

                User user = this.service.GetUserFromLoginBind(lumb);
                this.service.LoginUser(session, user);
                this.Redirect(response, "/home/index");
                return null;
            }
            this.Redirect(response, "/home/index");
            return null;
        }
    }
}
