using System.Collections;
using System.Collections.Generic;
using PizzaMore.Utility.Interfaces;

namespace PizzaMore.Utility
{
    public class CookieCollection : ICookieCollection
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
            //this.Count = 0;
        }

        public void AddCookie(Cookie cookie)
        {
            if (!this.Cookies.ContainsKey(cookie.Name))
            {
                this.Cookies.Add(cookie.Name, cookie);
            }
            
        }

        public void RemoveCookie(string cookieName)
        {
            this.Cookies.Remove(cookieName);
        }

        public bool ContainsKey(string key)
        {
            return this.Cookies.ContainsKey(key);
        }

        public int Count
        {
            get { return this.Cookies.Count; }
            
        }

        public Cookie this[string key]
        {
            get { return this.Cookies[key]; }
            set { this.Cookies[key] = value; }
        }

        public Dictionary<string, Cookie> Cookies { get; }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }
    }
}