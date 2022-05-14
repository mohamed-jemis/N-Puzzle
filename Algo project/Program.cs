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
                int[] temp = new int[n * n + 1];//passed to the function just for the merge
                bool is_solvable  = solvability.IS_solvable(inversions_check, temp, 0, inversions_check.Count - 1, n, blank_row);
                //Dictionary<List<int>, bool> c = new Dictionary<List<int>, bool>();

                if (is_solvable)
                {
                    Console.WriteLine(file);
                    //A* algorithm
                    Console.WriteLine("Solvable");

                    int[] ideal = get_ideal(n);

                    HashSet<string> closed_list = new HashSet<string>();
                    MinHeap active_list = new MinHeap();

                    int[] first_node_arr = puzzle.ToArray();
                    Node first_node = new Node(n, puzzle.ToArray(), null, ideal);

                    active_list.add(first_node);

                    Node chosen = new Node();
                    while (active_list.get_size() != 0)
                    {
                        chosen = active_list.pull();
                        closed_list.Add(Node.get_string(chosen.arr));
                        if (chosen.g_score == 0)
                        {

                            Console.WriteLine("wasalnaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                            Console.WriteLine(chosen.g_score);
                            break;
                        }
                        Node.create_children(chosen, closed_list, active_list, ideal);
                    }
                }
                else
                {
                    Console.WriteLine(file);
                    Console.WriteLine("Unsolvable");
                }
            }

        }

        //Creating goal state
        public static int[] get_ideal(int n)
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