using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace HttpServer
{
    class HttpProcessor
    {
        public HttpRequest Request { get; set; }

        public HttpResponse Response { get; set; }

        public IList<Route> Routes { get; set; }

        public HttpProcessor()
        {
            this.Routes = new List<Route>();
        }

        public void HandleClient(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                Request = GetRequest(stream);
                Response = RouteRequest();
            }
        }

        private HttpResponse RouteRequest()
        {
            var routes = this.Routes.Where(r => Regex.Match(Request.Url, r.UrlRegex).Success).ToList();
            if (routes.Count == 0)
            {
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.NotFound
                };
            }
            var matchingRoute = (from r in routes
                                where r.Method == Request.Method
                                select r).First();
            if (matchingRoute != null)
            {
                try
                {
                    return matchingRoute.Callable(Request);
                }
                catch (Exception e)
                {
                    return new HttpResponse()
                    {
                        StatusCode = ResponseStatusCode.InternalServerError
                    };
                }
                
            }
            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.MethodNotAllowed
            };
        }

        private HttpRequest GetRequest(Stream stream)
        {
            Header header = new Header(HeaderType.HttpRequest);
            var line = StreamUtils.ReadLine(stream);
            string[] requestLine = line.Split(' ');
            RequestMethod method;
            if (requestLine.Length != 3)
            {
                throw new Exception("Invalid request line.");
            }
            if (requestLine[0].ToLower() == "get")
            {
                method = RequestMethod.Get;
            }
            else
            {
                method = RequestMethod.Post;
            }
            
            string url = requestLine[1];

            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
                requestLine = line.Split(':');
                string name = requestLine[0];
                string value = requestLine[1].Trim();
                if (name == "Cookie")
                {
                    header.AddCookie(new Cookie(name, value));
                }
                else if(name == "Content-Length")
                {
                    header.ContentLength = value;
                }
                else
                {
                    header.OtherParameters.Add(name, value);
                }
            }
            if (header.ContentLength != null)
            {
                int totalBytes = Convert.ToInt32(header.ContentLength);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];
                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, totalBytes - bytesLeft);

                    bytesLeft -= n;
                }
                line = Encoding.ASCII.GetString(bytes);
            }
            var request = new HttpRequest()
            {
                Method = method,
                Url = url,
                Header = header,
                Content = line
            };

            return Request;
        } 
    }
}
