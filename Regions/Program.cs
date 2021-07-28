using System;
using System.IO;
using System.Linq;

namespace Regions
{
    class Program
    {
        public static int NumOfRegions(int[,] array)
        {
            bool[,] visited = new bool[array.GetLength(0), array.GetLength(1)];
            int res = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1 && !visited[i, j])
                    {
                        DFS(array, visited, i, j);
                        res++;
                    }
                }
            }
            return res;
        }
        public static void DFS(int[,] grid, bool[,] visited, int i, int j)
        {
            if (i < 0 || i >= grid.GetLength(0)) return;
            if (j < 0 || j >= grid.GetLength(1)) return;
            if (grid[i, j] != 1 || visited[i, j]) return;
            visited[i, j] = true;
            DFS(grid, visited, i + 1, j);
            DFS(grid, visited, i - 1, j);
            DFS(grid, visited, i, j + 1);
            DFS(grid, visited, i, j - 1);
        }

        public static int[,] TextToArray(string text)
        {
            var rows = text.Split(";");
            int[,] array = new int[rows.Length,rows[0].Split(",").Length];
            var row = 0;
            foreach (var r in rows)
            {
                var columns = r.Split(",");
                var column = 0;
                foreach (var c in columns)
                {
                    array[row, column] = Int32.Parse(c);
                    column++;
                }
                row++;
            }

            return array;
        }
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.ReadKey();
            }

            string text = System.IO.File.ReadAllText(args[0]);
            var arr = TextToArray(text);
            Console.WriteLine(NumOfRegions(arr));
        }
    }
}
