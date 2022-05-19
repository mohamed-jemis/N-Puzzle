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
            //Getting paths
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string testPath = projectPath + "\\Testcases";
            string[] files = Directory.GetFiles(testPath, "*.txt", SearchOption.AllDirectories);

            //Iterating over all testcases
            foreach (string file in files)
            {
                //Reading files
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                List<int> puzzle = new List<int>();
                List<int> inversions_check = new List<int>();

                string line = sr.ReadLine();
                int n = int.Parse(line);
                int blank_row = 0;

                //Creating puzzle array 
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

                //Checking solvability
                var watch = new System.Diagnostics.Stopwatch();
                int[] temp = new int[n * n + 1];//passed to the function just for the merge
                bool is_solvable  = solvability.IS_solvable(inversions_check, temp, 0, inversions_check.Count - 1, n, blank_row);                

                if (is_solvable)
                {
                    Console.WriteLine(file);
                    Console.WriteLine("Solvable");

                    //A* algorithm

                    HashSet<string> closed_list = new HashSet<string>();
                    MinHeap active_list = new MinHeap();
                    
                    Node first_node = new Node(n, puzzle.ToArray(), null);
                    
                    Console.WriteLine("enter choice");
                    string choice=Console.ReadLine();
                    
                    if (choice == "h")
                        distance.choice = true;

                    else
                        distance.choice = false;
                        
                    watch.Start();
                    
                    active_list.add(first_node);

                    Node chosen = new Node();
                    
                    while (active_list.get_size() != 0)
                    {
                        chosen = active_list.pull();
                        closed_list.Add(Node.get_string(chosen.arr));
                        if (chosen.h_score == 0)
                        {                            
                            Console.WriteLine(chosen.g_score);
                            break;
                        }
                        Node.create_children(chosen, closed_list, active_list);
                    }
                    //print_path(chosen);
                    watch.Stop();
                    Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
                }
                else
                {
                    Console.WriteLine(file);
                    Console.WriteLine("Unsolvable");
                    watch.Stop();
                }
            }

        }
        public static void print_path(Node node)
        {
            if (node == null)
                return;

            print_path(node.parent);
            
            for (int i = 0; i < node.N; i++)
            {
                for (int j = 0; j < node.N; j++)
                    Console.Write(node.arr[i * node.N + j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}