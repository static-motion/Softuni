using System;
using System.Text;
using PizzaMore.Utility.Interfaces;

namespace PizzaMore.Utility
{
    public class Header
    {
        public string Type { get; set; }

        public string Location { get; set; }

        public ICookieCollection Cookies { get; set; }

        public Header()
        {
            this.Type = "Content-Type: text/html";
            this.Cookies = new CookieCollection();
        }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.AddCookie(cookie);
        }

        public override string ToString()
        {
            StringBuilder componentsBuilder = new StringBuilder();
            componentsBuilder.AppendLine(this.Type);
            if (this.Cookies.Count > 0)
            {
                foreach (var cookie in this.Cookies)
                {
                    componentsBuilder.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }
            }
            if (!string.IsNullOrEmpty(Location))
            {
                componentsBuilder.AppendLine(Location);
            }
            componentsBuilder.AppendLine();
            componentsBuilder.AppendLine();

            return componentsBuilder.ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}