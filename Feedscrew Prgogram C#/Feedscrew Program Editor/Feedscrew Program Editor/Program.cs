using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Feedscrew_Program_Editor
{
    class Program
    {
        public static string logfile;
        //public static string[] words;

        static void Main(string[] args)
        {

            //Title and User input of file
            string title = "Welcome to Dr. L.J.'s Feedscrew Program Editor!";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(title + '\n');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("For all your editing needs, simply type in the name of the feedscrew file");
            Console.Write("without the extension");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" (For example: W12345-1)");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@" and I'll make your problems 
go away...");
            Console.Write("\nName of Feedscrew file: ");

            string inputfile = Console.ReadLine();

            //Open .RNC file and Check for Legitimacy
            try
            {
                logfile = File.ReadAllText(inputfile + ".RNC");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Opening File!   :(");
            }

            //Open .ARC file and replaces stuff with new commands
            string core = inputfile.Substring(3, 3);
            string mpfcore = inputfile.Substring(2, 4);
            string outputfile = inputfile + ".ARC";
            List<string> lines = logfile.Split('\n').ToList();
            List<string> words = new List<string>();
            List<List<string>> wordlist = new List<List<string>>();
            List<string> test = new List<string>();

            for (int i = 0; i < lines.Count; i++)
            {
                words = lines[i].Split(' ').ToList();

                for (int j = 0; j < words.Count; j++)
                {
                    //Simple replace whole word
                    words[j] = words[j].Replace("M17", "RET");
                    words[j] = words[j].Replace("G59", "ATRANS");
                    words[j] = words[j].Replace("@714", "STOPRE");
                    words[j] = words[j].Replace("L101", "L" + core + "1");
                    words[j] = words[j].Replace("L102", "L" + core + "2");
                    words[j] = words[j].Replace("L103", "L" + core + "3");
                    words[j] = words[j].Replace("L104", "L" + core + "4");
                    words[j] = words[j].Replace("L105", "L" + core + "5");
                    words[j] = words[j].Replace("L106", "L" + core + "6");
                    words[j] = words[j].Replace("%SPF101", "%_N_L" + core + "1_SPF");
                    words[j] = words[j].Replace("%SPF102", "%_N_L" + core + "2_SPF");
                    words[j] = words[j].Replace("%SPF103", "%_N_L" + core + "3_SPF");
                    words[j] = words[j].Replace("%SPF104", "%_N_L" + core + "4_SPF");
                    words[j] = words[j].Replace("%SPF105", "%_N_L" + core + "5_SPF");
                    words[j] = words[j].Replace("%SPF106", "%_N_L" + core + "6_SPF");
                    words[j] = words[j].Replace("%MPF" + mpfcore, "%_N_MPF" + mpfcore + "_SPF");

                }
                wordlist.Add(words);
            }

            // Print 2D list to .arc file

            using (StreamWriter writer = new StreamWriter(outputfile, false))
            {
                for (int i = 0; i < wordlist.Count; i++)
                {
                  
                   List<string> line = wordlist[i].S
                        writer.WriteLine(line.Cast<string>());
                  
                }
            }

                //          File.WriteAllLines(outputfile, wordlist.SelectMany(x=>x));



                //        for (int lineIndex = 0; lineIndex < lines.Count; lineIndex++)
                //          {
                //              for (int charIndex = 0; charIndex < lines[lineIndex].Length; charIndex++)
                //              {
                //                  //Moving words on to new line or moving somewhere else.
                //
                //                  if (words[lineIndex, charIndex] == "S1=R4")
                //                  {
                //                      words[i + 1].Add("N99910 S=R4");
                //                  }
                //              }
                //          }

                //Reconstruct 2D list into string array and Write to file.
                //          string[] newlines = new string[lines.Count];
                //          for (int i = 0; i < words.Count; i++)
                //          {
                //              for (int j = 0; j < words[i].Count; j++)
                //              {
                //                  newlines[i] += words[i][j] + ((i == words.Count - 1) ? "" : " ");
                //              }
                //          }
                //          File.WriteAllLines(outputfile, newlines);
                //File.WriteAllLines(outputfile, words.SelectMany(x => x)); 
                //File.WriteAllLines(outputfile, lines);
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAnnnnd it's gone!");
            //Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nYou're .RNC file...");
            //Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nIt's gone!");
            //Thread.Sleep(1500);
            Console.ReadKey();
        }
    }
}
