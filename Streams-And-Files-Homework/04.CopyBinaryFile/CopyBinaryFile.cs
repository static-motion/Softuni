using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class CopyBinaryFile
{
    static string FilePath = "../../file.gif";
    static string FileCopyPath = "../../file-copy.gif";
    static void Main()
    {
        using (var source = new FileStream(FilePath, FileMode.Open))
        {
            using (var destination = new FileStream(FileCopyPath, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while(true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
        
    }
}

