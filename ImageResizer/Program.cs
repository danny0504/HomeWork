using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");
            string asyncDestinationPath = Path.Combine(Environment.CurrentDirectory, "output2"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);
            imageProcess.Clean(asyncDestinationPath);

            //非同步
            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();
            Console.WriteLine($"同步花費時間: {sw.ElapsedMilliseconds} ms");

            //同步
            Stopwatch asyncSW = new Stopwatch();
            asyncSW.Start();
            imageProcess.AsyncResizeImages(sourcePath, asyncDestinationPath, 2.0);
            asyncSW.Stop();

            Console.WriteLine($"非同步花費時間: {asyncSW.ElapsedMilliseconds} ms");
            Console.WriteLine($"效率:{((double)(sw.ElapsedMilliseconds- asyncSW.ElapsedMilliseconds)/ (double)sw.ElapsedMilliseconds)*100}%");
            Console.ReadKey();
        }
    }
}
