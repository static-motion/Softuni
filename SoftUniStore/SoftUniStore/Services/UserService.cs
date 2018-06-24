using System;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleHttpServer.Models;
using SoftUniStore.BindingModels;
using SoftUniStore.Models;

namespace SoftUniStore.Services
{
    public class UserService : Service
    {
        public bool IsRegisterModelValid(RegisterUserBindingModel rubm)
        {
            if (!Regex.IsMatch(rubm.Email, @"[a-zA-Z]+@[a-z]+.[a-z]+"))
                return false;

            if (!Regex.IsMatch(rubm.Password, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}"))
                return false;

            if (!Regex.IsMatch(rubm.FullName, @"^[a-zA-Z -.]+$"))
                return false;

            if (rubm.Password != rubm.ConfirmPassword)
                return false;
            if (this.Context.Users.Any(user => user.Email == rubm.Email))
            {
                return false;
            }

            return !string.IsNullOrEmpty(rubm.FullName);
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel rubm)
        {
            User user = new User
            {
                Email = rubm.Email,
                FullName = rubm.FullName,
                Password = rubm.Password
            };
            return user;
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

        public bool IsLoginBindValid(LoginUserBindingModel lumb)
        {
            return this.Context.Users.Any(user => user.Email == lumb.Email && user.Password == lumb.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel lumb)
        {
            return this.Context.Users.FirstOrDefault(user => (user.Email == lumb.Email) && (user.Password == lumb.Password));
        }

        public void LoginUser(HttpSession session, User user)
        {
            this.Context.Logins.Add(new Login()
            {
                SessionId = session.Id,
                User = user,
                IsActive = true
            });
            this.Context.SaveChanges();
        }
    }
}
