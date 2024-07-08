namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // fib(0) = 1
            // fib(1) = 1
            // fib(n) = fib(n-1) + fib(n-2)
            // (0) 1 1 2 3 5 8 13 21 34 ...

            // int[] array = new int[10_000];
            // for (int i = 0; i < array.Length; i++) array[i] = 1;

            // DateTime start = DateTime.Now;

            // long eighthFibNumber = FibonacciIterative(50);
            // Console.WriteLine(eighthFibNumber);

            // long factorial = FactorialRecursively(10);
            // Console.WriteLine(factorial);

            // DateTime finish = DateTime.Now;
            // TimeSpan diff = finish - start;
            // Console.WriteLine($"Elapsed time: {diff.TotalSeconds:f5}");

            //AnalyzeRecursionChain(5);

            /*int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
                min = Math.Min(min, array[i]);*/

            /*int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                    Console.WriteLine($"{i}, {j}");
            }*/

            /* int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

             Dictionary<int, int> occurencesByNumber = new Dictionary<int, int>();
             for (int i = 0; i < array.Length; i++)
             {
                 if (!occurencesByNumber.ContainsKey(array[i]))
                     occurencesByNumber[array[i]] = 0;
                 occurencesByNumber[array[i]]++;
             }

             int[] filteredArray = array.Where(x => occurencesByNumber[x] % 2  == 0).ToArray();
             Console.WriteLine(string.Join(", ", filteredArray));*/

            /*int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Dictionary<int, int> occurencesByNumber = new Dictionary<int, int>();
            int max = 0, maxElement = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!occurencesByNumber.ContainsKey(array[i]))
                    occurencesByNumber[array[i]] = 0;
                int currentOccurances = ++occurencesByNumber[array[i]];

                if (currentOccurances > max)
                {
                    max = currentOccurances;
                    maxElement = array[i];
                }
            }

            int[] filteredArray = array.Where(x => occurencesByNumber[x] % 2 == 0).ToArray();
            Console.WriteLine(string.Join(", ", filteredArray));

            if (max >= array.Length / 2 + 1)
                Console.WriteLine($"This array has a majorant: {maxElement}");
            else Console.WriteLine("This array does not have a majorant.");*/

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Dictionary<int, int> occurencesByNumber = new Dictionary<int, int>();
            int max = 0, firstMaxElement = 0, maxElementSum = 0, maxElementCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!occurencesByNumber.ContainsKey(array[i]))
                    occurencesByNumber[array[i]] = 0;
                int currentOccurances = ++occurencesByNumber[array[i]];

                if (currentOccurances > max)
                {
                    max = currentOccurances;
                    firstMaxElement = array[i];
                    maxElementSum = 0;
                    maxElementCount = 0;
                }

                if (currentOccurances == max) 
                {
                    maxElementSum += array[i];
                    maxElementCount++;
                }
            }

            int[] filteredArray = array.Where(x => occurencesByNumber[x] % 2 == 0).ToArray();
            Console.WriteLine(string.Join(", ", filteredArray));

            if (max >= array.Length / 2 + 1)
                Console.WriteLine($"This array has a majorant: {firstMaxElement}");
            else Console.WriteLine("This array does not have a majorant.");

            Console.WriteLine($"The mode is: {(double)maxElementSum / maxElementCount:f3}");
        }

        static void AnalyzeRecursionChain(int n)
        {
            if (n == 0) return;

            Console.WriteLine($"Pre-execution step for {n}. {new string('*', n)}");
            AnalyzeRecursionChain(n - 1);
            Console.WriteLine($"Post-execution step for {n}. {new string('#', n)}");
        }

        // 10 000 -> 0.01128
        // More than 10 000 -> Stack overflow
        static int SumRecursively(int index, int[] numbers)
        {
            if (index == numbers.Length) return 0;
            return numbers[index] + SumRecursively(index + 1, numbers);
        }

        // 10 000 -> 0.01660
        static int SumIteratively(int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++) result += numbers[i];
            return result;
        }

        static long FactorialRecursively(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * FactorialRecursively(n- 1);
        }

        static void EndlessRecursionLoop() => EndlessRecursionLoop();

        // n = 40 => 1.01526s
        // n = 50 => 95.34920s
        static long FibonacciRecursive(int n)
        {
            if (n == 0 || n == 1) return 1;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        // n = 40 => 0.01126s
        // n = 50 => 0.01058s
        static long FibonacciIterative(int n)
        {
            long a = 1; long b = 1;
            for (int i = 2; i <= n; i++)
            {
                long next = a + b;
                a = b;
                b = next;
            }

            return b;
        }

        static void Demo(int n) // max(n^2, 1) => O(n^2)
        {
            if(n % 2 == 0) // O(n^2)
            {
                for (int i = 0; i < n; i++) // n iterations, in total n*n=n^2
                {
                    for(int j = 0; j < n; j++) // n iterations
                    {
                        Console.WriteLine($"{i}, {j}"); 
                    }
                }
            }
            else // O(1)
            {
                Console.WriteLine("odd");
            }
        }
    }
}
