using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace CpuMonitor
{
    class Program
    {
        static void Main(string[] args)
        {

            PerformanceCounter cpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            while (true)
            { 
                Console.Write("CPU Usage : {0}% \n", cpuCount.NextValue());
                Thread.Sleep(1000);
            }

        }
    }
}
