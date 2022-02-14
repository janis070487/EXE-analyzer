using System;

namespace exe_analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "ConsoleApplication1.exe";
            byte[] data = null;
            MyFileLoad file = new MyFileLoad(path);
            data = file.Load();
            IMAGE_DOS_HEADER IDH = new IMAGE_DOS_HEADER(data);
            IDH.read();
            Console.WriteLine(IDH.GetData());
            
            Console.WriteLine("Faila lielums " + data.Length + " byte");
            IDH.FormatData();
            string[] formatdata = IDH.GetFormatData();
            for(int i = 0; i < formatdata.Length; i++)
            {
                Console.WriteLine(formatdata[i]);
            }


        }
    }
}
