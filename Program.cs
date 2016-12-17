using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bipartite
{
    class Program
    {
        static void Main(string[] args)
        {
            int vertex = Convert.ToInt32(Console.ReadLine());
            LinkedList<Int32>[] graph = new  LinkedList<Int32>[vertex];
            int[] color = new Int32[vertex];
            for (int i = 0; i < vertex; i++)
            {
                color[i] = -1;
                graph[i] = new LinkedList<int>();
                string[] str = Console.ReadLine().Split(' ');
                foreach (string s in str)
                {
                    if(s != "")
                    graph[i].AddLast(Convert.ToInt32(s));
                }
            }
            

            //int node = 0,parent=-1;
            //    color[node] = 0;
            //    stack.Push(node);

            //while (node >=0)
            //{
            //    if (color[node] < 0)
            //        color[node] = 1 - color[parent];
            //    else
            //    {
            //        if (parent>=0 && color[node] == color[parent])
            //        { 
            //            Console.WriteLine("Not Success");
            //            break;
            //        }
            //    }
            //    parent = node;

            //    foreach (int n in graph[node])
            //    {
            //        node = n;
            //        stack.Push(n);
            //    }
            //    stack.Pop();
            //}
            //if (stack.Count == 0)
            //    Console.WriteLine("Success");

            Stack<Int32> stack = new Stack<Int32>();

            int root = 1,parent=1;
            color[root] = 0;
            stack.Push(root);
            while (stack.Count != 0)
            {
                foreach (int node in graph[root])
                {
                    parent = root;
                    if (color[node] <= 0)
                    {
                        color[node] = 1 - color[parent];
                        stack.Push(node);
                    }
                    else if (color[parent] == color[node])
                    {
                        Console.WriteLine("Not 2 Colorable");
                        return;
                    }

                }
                root = stack.Peek();
                stack.Pop();
            }
            if(stack.Count==0)
            Console.WriteLine("2 Colorable");
            Console.ReadKey();

        }
    }
}
