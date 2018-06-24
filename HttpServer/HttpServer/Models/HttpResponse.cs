using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class HttpResponse
    {
        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public HttpResponse Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentAsUtf8
        {
            set { this.Content = Encoding.UTF8.GetBytes(value); }
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            response.AppendLine($"HTTP/1.0 {StatusCode} {StatusMessage}");
            response.AppendLine($"{Header}");
            return response.ToString();
        }
    }
}
