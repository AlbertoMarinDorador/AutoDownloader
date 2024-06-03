using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    class ReadText
    {
        public static void Main()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\DIRECTORIO PRUEBAS\WriteLines.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
