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
                                                // invCnt = solvability.inversion_count(inversions_check, temp, 0, inversions_check.Count - 1);//here we will call the IS_solvable function
               bool is_solvable  = solvability.IS_solvable(inversions_check, temp, 0, inversions_check.Count - 1, n, blank_row);
                if (is_solvable)
                {
                    int[] ideal = get_ideal(n);
                    List<int[]> closed_list = new List<int[]>();
                    MinHeap active_list = new MinHeap();
                    int[] first_node_arr = puzzle.ToArray();
                    Node first_node = new Node();
                    first_node.arr = first_node_arr;
                    first_node.parent = null;
                    first_node.N = n;
                    first_node.g_score = distance.manhatten(n, first_node,ideal);
                    active_list.add(first_node);
                    int counter=0;
                    Node chosen = new Node();
                    while(active_list.get_size()!=0)
                    {
                        
                        chosen = active_list.pull();
                        for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < n; j++)
                                {
                                    Console.Write(chosen.arr[i * n + j]);
                                    Console.Write(" ");
                                }
                                Console.WriteLine();
                        }
                            if (chosen.g_score==0)
                        {
                            break;
                        }
                        Node.create_children(chosen, closed_list, active_list,ideal);
                        closed_list.Add(chosen.arr);
                    }
                        //test--------------
                }
                else
                    Console.WriteLine("bas ya 3eglll");

               
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
        static int[] get_ideal(int n)
        {
            int[] arr = new int[(n * n)];
            for (int i = 0; i < n * n; i++)
            {
                arr[i] = i + 1;
                if (i == (n * n)-1)
                    arr[i] = 0;
            }
            return arr;
        }
    }
}