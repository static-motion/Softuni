using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleHttpServer.Models;

namespace HttpServer
{
    static class StreamUtils
    {
        public static string ReadLine(Stream stream)
        {
            StringBuilder streamData = new StringBuilder();
            char streamByte;
            while(true)
            {
                streamByte = (char)stream.ReadByte();
                if (streamByte == '\n')
                {
                    break;
                }
                if (streamByte == '\r')
                {
                    continue;
                }
                if (streamByte == -1)
                {
                    Thread.Sleep(1);
                    continue;
                }
                streamData.Append((char)streamByte);               
            }

            return streamData.ToString();
        }

        public static void WriteResponse(Stream stream, HttpResponse response)
        {
            byte[] responseHeader = Encoding.UTF8.GetBytes(response.ToString());
            stream.Write(responseHeader, 0, responseHeader.Length);
            stream.Write(response.Content, 0, response.Content.Length);
        }
    }
}
