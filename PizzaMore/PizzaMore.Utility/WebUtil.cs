using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using PizzaMore.Data;
using PizzaMore.Data.Models;
using PizzaMore.Utility.Interfaces;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            if (requestMethod.ToLower() == "post")
            {
                return true;
            }
            return false;
        }

        public static bool IsGet()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            if (requestMethod.ToLower() == "get")
            {
                return true;
            }
            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string requestParameters = Environment.GetEnvironmentVariable("QUERY_STRING");
            return RetrieveRequestParameters(requestParameters);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string requestParameters = Console.ReadLine();
            return RetrieveRequestParameters(requestParameters);
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string parameter)
        {
            string requestParameters = WebUtility.UrlDecode(parameter);
            string[] nameValuePair = requestParameters.Split('&');
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (var pair in nameValuePair)
            {
                string name = pair.Split('=')[0];
                string value = "";
                if (!string.IsNullOrEmpty(pair)) //PROBLEM
                {
                    value = pair.Split('=')[1];
                }
                parameters.Add(name, value);
            }            
            return parameters;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieHeader = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (string.IsNullOrEmpty(cookieHeader))
            {
                return new CookieCollection();
            }
            CookieCollection cookies = new CookieCollection();

            string[] cookiesNamesAndValues = cookieHeader.Split(';');
            cookiesNamesAndValues = cookiesNamesAndValues.Select(c => c.Trim()).ToArray();
            foreach (var cookieNameAndValue in cookiesNamesAndValues)
            {
                string cookieName = cookieNameAndValue.Split('=')[0];
                string cookieValue = cookieNameAndValue.Split('=')[1];
                Cookie cookie = new Cookie(cookieName, cookieValue);
                cookies.AddCookie(cookie);
            }

            return cookies;
        }

        public static Session GetSession()
        {
            var cookies = GetCookies();
            if (cookies.ContainsKey("sid"))
            {
                PizzaMoreContext sessionContext = new PizzaMoreContext();
                string sessionId = cookies["sid"].Value;
                var session = sessionContext.Sessions.FirstOrDefault(s => s.Id == sessionId);
                return session;
            }
            return null;
        }

        public static void PrintFileContent(string path)
        {
            string fileContent = File.ReadAllText(path);
            Console.WriteLine(fileContent);
        }

        public static void PageNotAllowed()
        {
            string gamePath = "../htdocs/pm/Game/index.html";
            PrintFileContent(gamePath);
        }
    }
}