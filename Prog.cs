using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSchedule();
            SearchGoogle("cat pictures");
        }

         public static void SearchGoogle(string term)
        {
            // Search Google for this term.
            Process.Start("https://www.google.com/?q=" + term);
        }

        public static void RunSchedule()
        {
            string path = Path.GetFullPath("C:\\MyTest") + "\\"
                            + DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "_Log.txt";
            Process.Start(@"C:\\MyTest\friends_s01e01_720p_bluray_x264-sujaidr.mkv");
            

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
