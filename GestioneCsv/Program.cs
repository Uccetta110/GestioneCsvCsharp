using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace GestioneCsv
{
    internal class Program
    {
        protected static string directoryPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar;
        protected static List<string> jsonDirectories = new List<string>();
        protected static List<string> jsonNames = new List<string>();
        protected static List<CV> CVs = new List<CV>();
        public const int len = 69;


        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                int r = ScegliCSV();
                int r1 = MidMenu();
                switch (r1)
                {
                    case 0:
                        return;
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        CaricaCV(r);
                        flag = false;
                        break;
                }

            }


        }

        static public int ScegliCSV()
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
                return r;
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

        static public void CaricaCV(int n)
        {
            string fullPath = directoryPath + "CV\\" + jsonDirectories[n - 1];
            try
            {
                string json = File.ReadAllText(fullPath);
                CV p = JsonConvert.DeserializeObject<CV>(json);

                if (p != null)
                    CVs.Add(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nel file " + fullPath + ": " + ex.Message);
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

        static public int MidMenu()
        {
            while (true)
            {
                int r = -1;
                Console.WriteLine("=============================== MENU ================================");
                Console.WriteLine("|                                                                   |");
                Console.WriteLine("| [0] Esci dal Programma                                            |");
                Console.WriteLine("|                                                                   |");
                Console.WriteLine("| [1] Carica altri CV                                               |");
                Console.WriteLine("|                                                                   |");
                Console.WriteLine("| [2] Visualizza CVs                                                |");
                Console.WriteLine("|                                                                   |");
                while (r < 0 || r > 2)
                {
                    string r_temp = Console.ReadLine().Trim();
                    if (int.TryParse(r_temp, out int r_parsed))
                        r = Convert.ToInt32(r_temp);

                    if (r < 0 || r > 2)
                    {
                        Console.Clear();
                        Console.WriteLine("| Scelta non valida, riprova.                                       |");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                return r;
            }
        }
    }
}
