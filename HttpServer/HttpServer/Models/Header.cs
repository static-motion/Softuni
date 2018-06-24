using System.Collections.Generic;
using System.Text;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.OtherParameters = new Dictionary<string, string>();
            this.Cookies = new CookieCollection();
        }

        public HeaderType Type { get; set; }    

        public string ContentType { get; set; }

        public string ContentLength { get; set; }

        public Dictionary<string, string> OtherParameters { get; set; }

        public CookieCollection Cookies { get; set; }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.AddCokie(cookie);
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine("Content-Type: " + this.ContentType);
            if (!string.IsNullOrEmpty(ContentLength))
            {
                header.AppendLine(ContentLength);
            }
            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.Cookies.ToString());
                }
                else
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine($"Set-Cookie: {cookie.ToString()}");
                    }
                } 
            }
            if (!string.IsNullOrEmpty(this.ContentLength))
            {
                header.AppendLine("Content-Length: " + this.ContentLength);
            }
            foreach (var other in OtherParameters)
            {
                header.AppendLine($"{other.Key}: {other.Value}");
            }
            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}