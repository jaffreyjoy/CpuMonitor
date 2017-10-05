using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSchedule();
        }

        public static void RunSchedule()
        {
            string path = Path.GetFullPath("C:\\MyTest") + "\\"
                            + DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "_Log.txt";

            try
            {
                if(!File.Exists(path))
                {
                    //File.Create(path);
                    string errorLogPath = @"C:\MyTest.txt";

                    string createText = "Hello" + Environment.NewLine;
                    string appendText = "This is insane" + Environment.NewLine;

                    while (true)
                    {

                        File.WriteAllText(path, createText);
                        File.AppendAllText(errorLogPath, appendText);

                    }
                }
            }

            catch(Exception ex)
            {
                string errorLogPath = @"C:\MyTest.txt";
                string appendText = "This is insane" + Environment.NewLine;
                File.AppendAllText(errorLogPath, appendText);
            }
        }
    }
}
