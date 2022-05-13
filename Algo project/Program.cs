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
                //Console.WriteLine(file);
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                List<int> puzzle = new List<int>();
                List<int> inversions_check = new List<int>();
                string line = sr.ReadLine();
                int n = int.Parse(line);
                int blank_row = 0;
                //Console.WriteLine(n);

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
                        puzzle.Add(int.Parse(numbers[j]));
                        if (int.Parse(numbers[j]) == 0)
                            blank_row = n - i;
                        else
                            inversions_check.Add(int.Parse(numbers[j]));
                    }
                }
                fs.Close();

                int invCnt = 0;
                int[] temp = new int[n * n + 1];//passed to the function just for the merge
                invCnt = solvability.inversion_count(inversions_check, temp, 0, inversions_check.Count - 1);//here we will call the IS_solvable function

                //Console.WriteLine(invCnt + " " + blank_row);
                //if (n % 2 != 0)
                //    if (invCnt % 2 == 0 && invCnt != 0)
                //        Console.WriteLine("solvable");
                //    else
                //        Console.WriteLine("unsolvable");
                //else
                //    if (invCnt%2 == blank_row%2 || invCnt == 0)
                //        Console.WriteLine("unsolvable");
                //    else
                //        Console.WriteLine("solvable");

                //for (int i = 0; i < n; i++)
                //{
                //    for (int j = 0; j < n; j++)
                //    {
                //        Console.Write(puzzle[i * n + j]);
                //        Console.Write(" ");
                //    }
                //    Console.WriteLine();
                //}

                //int[] arr = {100, 19, 3, 8, 1, 17, 16, 25, 60, 5};
                //MinHeap open = new MinHeap(arr.ToList());
                //open.add(0);

                //for (int i = 0; i <= arr.Count(); i++)
                //    Console.Write(open.pull() + " ");

                //Console.WriteLine();

            }
        }
    }
}