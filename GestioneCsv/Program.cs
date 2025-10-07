using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace GestioneCsv
{
    internal class Program
    {
        protected static string directoryPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar;
        protected static List<string> jsonDirectories = new List<string>();
        protected static List<string> jsonNames = new List<string>();
        public const int len = 69;


        static void Main(string[] args)
        {
            CaricaCSV();

        }

        static public void CaricaCSV()
        {
            ControllaCV();
            while (true)
            {
                int r = -1;
                int n = JsonNamesOut();

                while (r < 0 || r > n)
                {
                    string r_temp = Console.ReadLine().Trim();
                    if (int.TryParse(r_temp, out int r_parsed))
                        r = Convert.ToInt32(r_temp);

                    if (r < 0 || r > n)
                    {
                        Console.Clear();
                        Console.WriteLine("| Scelta non valida, riprova.                                       |");
                        Console.ReadKey();
                        Console.Clear();
                        n = JsonNamesOut();
                    }
                }
                switch (r)
                {
                    case 0:
                        return;
                    default:
                        break;
                }
                int count = -1;
                int num = -1;
            }
        }

        static public void ControllaCV()
        {
            string CVpath = directoryPath + "CV\\";

            IEnumerable<string> jsonFiles = Directory.EnumerateFiles(CVpath, "*.json");
            foreach (string fullPath in jsonFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(fullPath);
                jsonNames.Add(fileName);
            }

            string[] jsonFilesArray = Directory.GetFiles(CVpath, "*.json");

            foreach (string fullPath in jsonFilesArray)
            {
                string fileName = Path.GetFileName(fullPath);
                jsonDirectories.Add(fileName);
            }
        }

        static public int JsonNamesOut()
        {
            int n = 1;
            Console.WriteLine("============================= CARICA CP =============================");
            Console.WriteLine("|                                                                   |");
            Console.WriteLine("| [0] Esci dal Caricamento                                          |");
            Console.WriteLine("|                                                                   |");
            foreach (string file in jsonNames)
            {
                string temp = "| [" + n + "] " + file;
                Console.WriteLine(temp.PadRight(len - 1) + "|");
                Console.WriteLine("|                                                                   |");
                n++;
            }
            return n;
        }
    }
}
