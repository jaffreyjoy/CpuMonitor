using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace CpuMonitor
{
    class Program
    {
        static System.Diagnostics.Process process = new System.Diagnostics.Process();
        static System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static PerformanceCounter cpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        static PerformanceCounter memCount = new PerformanceCounter("Memory", "% Committed Bytes in Use");
        static Stopwatch stopWatch = new Stopwatch();
        static TimeSpan ts;

        static void Main(string[] args)
        {
            //a.Speak("Hey Jerry here!!!!!");
            //a.Speak("CPU Monitor is monitoring your CPU and RAM usage now!!!!!");
            //aSpeak("In case of extremely high usage appropriate messages will be sent and necessary measures will be taken!!!!!");

            String cpuMesg = String.Format("Current CPU Usage is {0}%", cpuCount.NextValue());
            String ramMesg = String.Format("You are currently using {0}% of your RAM", (int)memCount.NextValue());


            //aSpeak(cpuMesg);
            //aSpeak(ramMesg);

            int[] cflag = new int[10];
            int i = 0;
            int ix = 0;
            stopWatch.Start();
            while (true)
            {
                int cCount = (int)cpuCount.NextValue();
                double mCount = memCount.NextValue();
                Console.Write("CPU Usage : {0} % \n", cCount);
                Console.Write("RAM Usage : {0}% \n", mCount);
                if (cCount > 10)
                {
                    cflag[i++] = 1;
                    Console.WriteLine("[{0}]", string.Join(", ", cflag));
                    if (i!=0)
                    {
                        if (cflag[i - 1] == 0)
                        {
                            stopWatch.Stop();
                            ts = stopWatch.Elapsed;
                            Console.WriteLine("{0}", ts.Seconds);
                            stopWatch.Reset();
                            stopWatch.Start();
                            Console.WriteLine("restarted1");
                        }              
                    }
                    else if(ix!=0)
                    {
                        if (cflag[9] == 0)
                        {
                            stopWatch.Stop();
                            ts = stopWatch.Elapsed;
                            Console.WriteLine("{0}", ts.Seconds);
                            stopWatch.Reset();
                            stopWatch.Start();
                            Console.WriteLine("restarted2");
                        }
                    }
                    if (i == 10)
                        i = 0;
                }    
                else
                {
                    cflag[i++] = 0;
                    Console.WriteLine("[{0}]", string.Join(", ", cflag));
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    Console.WriteLine("{0}", ts.Seconds);
                    stopWatch.Reset();
                    stopWatch.Start();
                    Console.WriteLine("restarted3");
                    if (i == 10)
                        i = 0;
                }
                if (cflag.Sum() == 10)
                {
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    Console.WriteLine("sum=Ten  {0}", ts.Seconds);
                    Console.WriteLine("[{0}]", string.Join(", ", cflag));
                    if (ts.Seconds > 9)
                    {
                        aSpeak("ALERT!! Your CPU Usage is extremely High");
                        aSpeak("System will start shutdown process in 10 seconds");
                        aSpeak("Please save your work and Brace for Impact");
                        //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        //startInfo.FileName = "cmd.exe";
                        //startInfo.Arguments = "shutdown /l /t 10";
                        //process.StartInfo = startInfo;
                        //process.Start();
                        Thread.Sleep(10000);


                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine("shutdown /l");

                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();
                        Console.WriteLine(cmd.StandardOutput.ReadToEnd());


                        stopWatch.Reset();
                        stopWatch.Start();
                        Console.WriteLine("restarted4");
                    }
                }
                ix++;
                Thread.Sleep(1000);
                //stopWatch.Reset();
                //stopWatch.Start();
                //Console.WriteLine("restarted4");
            }

        }

        public static void aSpeak(String mesg)
        {
            synth.Speak(mesg);
        }

    }
}
