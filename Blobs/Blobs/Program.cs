using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Core;
using Blobs.Core.Factories;
using Blobs.Interfaces;
using Blobs.IO;

namespace Blobs
{
    class Program
    {
        static void Main(string[] args)
        {
            var blobFactory = new BlobFactory();
            var blobsData = new BlobsData();
            var inputReader = new ConsoleReader();
            var outputWriter = new ConsoleWriter();
            Engine engine = new Engine(blobFactory, blobsData, inputReader, outputWriter);
            engine.Run();
        }
    }
}
