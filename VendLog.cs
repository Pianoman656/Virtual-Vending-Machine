using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendLog
    {  
        public static void Log(string str)
        {
            try
            {
                string logFile = "C:\\Users\\Student\\workspace\\c-sharp-mini-capstone-module-1-team-3\\Log.txt";

                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    sw.WriteLine($">{DateTime.Now} {str}");
                }

            }
            catch (IOException vendx)
            {
                Console.WriteLine($"Log Error. Please Contact Local Vendor ");
                Console.WriteLine(vendx.Message);
            }
        }
    }
}
