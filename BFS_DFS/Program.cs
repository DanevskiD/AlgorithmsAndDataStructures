namespace BFS_DFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startDir = Console.ReadLine();
            LayeredDFS(startDir, 1);
        }

        static void BFS(string startDir)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startDir);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                Console.WriteLine(current);

                foreach (var subDirectory in Directory.EnumerateDirectories(current))
                    queue.Enqueue(subDirectory);
            }
        }

        static void LayeredBFS(string startDir)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startDir);

            int depth = 1;
            while (queue.Count > 0)
            {
                int iterationsCount = queue.Count;
                Console.WriteLine($"Starting the iteration of {iterationsCount} directories at depth #{depth}");

                for (int i = 0; i < iterationsCount; i++)
                {
                    string current = queue.Dequeue();
                    Console.WriteLine(current);

                    foreach (var subDirectory in Directory.EnumerateDirectories(current))
                        queue.Enqueue(subDirectory);
                }

                depth++;
            }
        }

        static void DFS(string path)
        {
            Console.WriteLine(path);
            foreach(var subDirectory in Directory.EnumerateDirectories(path))
                DFS(subDirectory);
        }

        static void LayeredDFS(string path, int depth)
        {
            Console.WriteLine($"At depth {depth}: {path}");
            foreach (var subDirectory in Directory.EnumerateDirectories(path))
                LayeredDFS(subDirectory, depth + 1);
        }
    }
}
