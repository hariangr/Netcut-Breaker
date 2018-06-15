using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nc
{
    class Program
    {
        static bool editHost = true;
        static bool editArcai = true;
        
        static String toEdit = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        static String arcaiPath = "C:\\Program Files (x86)\\arcai.com";
        static String arcaiPathAlt = "C:\\Program Files\\arcai.com";

        static void Main(string[] args)
        {
            Console.WriteLine("Let's mess with Netcut!!!");

            if (editHost)
            {
                try
                {
                    System.IO.File.SetAttributes(toEdit, System.IO.FileAttributes.Normal);
                    var before = System.IO.File.ReadAllText(toEdit);

                    String[] toWrite = new string[] { before, "192.168.1.99	www.arcai.com", "192.168.1.100	arcai.com" };

                    System.IO.File.WriteAllLines(toEdit, toWrite);
                    Console.WriteLine("Success editing hosts file");
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed editing hosts file");
                    throw;
                }
            }

            if (editArcai)
            {
                string toDelete = System.IO.Directory.Exists(arcaiPath) ? arcaiPath : arcaiPathAlt;

                foreach (var item in System.IO.Directory.EnumerateFiles(toDelete))
                {
                    Console.WriteLine(item + " Deleted");

                    try
                    {
                        System.IO.File.Delete(item);
                    }
                    catch
                    {
                        Console.WriteLine("Failed to delete " + item);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
