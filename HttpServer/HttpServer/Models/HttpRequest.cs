using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    class HttpRequest
    {
        public RequestMethod Method { get; set; }

        public string Url { get; set; }

        public Header Header { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            StringBuilder request = new StringBuilder();
            request.AppendLine($"{Method} {Url} HTTP/1.0");
            request.AppendLine($"{Header}");
            if (!string.IsNullOrEmpty(this.Content))
            {
                request.AppendLine($"{Content}");
            }

            return request.ToString();
        }
    }
}
