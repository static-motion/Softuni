using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PizzaForum.BindingModels;
using PizzaForum.Models;

namespace PizzaForum.Services
{
    class ForumService : Service
    {
        public bool IsViewModelValid(RegisterUserBindingModel rubm)
        {
            if (!Regex.IsMatch(rubm.Username, @"^[a-z0-9]{3,}$"))
                return false;

            if (rubm.Email.IndexOf("@") == -1)
                return false;

            if (this.Context.Users.Any(user => user.Username == rubm.Username || user.Email == rubm.Email))
                return false;

            if (!Regex.IsMatch(rubm.Password, @"^[0-9]{4}$") || rubm.Password != rubm.ConfirmPassword)
                return false;

            return true;
        }

        public User GetUserFromBind(RegisterUserBindingModel rubm)
        {
            return new User()
            {
                Username = rubm.Username,
                Password = rubm.Password,
                Email = rubm.Email,

            };
        }

        public void RegisterUser(User user)
        {
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }

            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }
    }
}
