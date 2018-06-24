using System;
using Blobs.Interfaces;

namespace Blobs.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}