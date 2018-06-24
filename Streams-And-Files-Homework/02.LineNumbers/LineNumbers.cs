using System;                                                                        
using System.IO;                                                                     
                                                                                     
class LineNumbers                                                                    
{                                                                                    
    static void Main()                                                               
    {                                                                                
        int lineNumber = 1; //Може и да започва от 0, но реших, че ми харесва повече с 1.                                                          
        using (var reader = new StreamReader(@"../../FileWithoutLineNumbers.txt"))       
        {                                                                            
            using (var writer = new StreamWriter(@"../../FileWithLineNumbers.txt"))      
            {                                                                        
                string line = reader.ReadLine();                                     
                while (line != null)                                                 
                {                                                                    
                    writer.WriteLine(lineNumber + "." + " " + line);                                
                    lineNumber++;
                    line = reader.ReadLine();                                                                 
                }                                                                    
            }                                                                        
        }                                                                            
    }                                                                                
}                                                                                    
                                                                                     
                                                                                     