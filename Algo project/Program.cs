using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace npuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string testPath = projectPath + "\\Testcases";
            string[] files = Directory.GetFiles(testPath, "*.txt", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                List<List<int>> puzzle = new List<List<int>>();
                string line = sr.ReadLine();
                int n = int.Parse(line);
                Console.WriteLine(n);

                for (int i = 0; i < n; i++)
                    puzzle.Add(new List<int>());

                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine();
                    if (line == "")
                    {
                        i--;
                        continue;
                    }
                    string[] numbers = line.Split(" ");
                    for (int j = 0; j < n; j++)
                    {
                        puzzle[i].Add(int.Parse(numbers[j]));
                    }
                }
                fs.Close();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(puzzle[i][j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                
            }
        }
    }
}