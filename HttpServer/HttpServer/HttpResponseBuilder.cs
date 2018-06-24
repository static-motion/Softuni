using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace HttpServer
{
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string html = File.ReadAllText("../../Resources/Pages/500.html");
            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.InternalServerError,
                ContentAsUtf8 = html
            };
        }

        public static HttpResponse NotFound()
        {
            string html = File.ReadAllText("../../Resources/Pages/404.html");
            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.NotFound,
                ContentAsUtf8 = html
            };
        }
    }
}
