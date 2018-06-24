using System;
using Blobs.Interfaces;

namespace Blobs.IO
{
    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}