namespace Combinatorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

           /* int permutationsCount = GeneratePermutations(array, new bool[array.Length], new List<int>(capacity: array.Length), 1);
            Console.WriteLine($"Total permutations generated: {permutationsCount}");*/

            int k = int.Parse(Console.ReadLine());

            DateTime start = DateTime.Now;

            // int combinationsCount = GenerateCombinationsWithRepetitions(k, array, new List<int>(capacity: k), 1);
            // int combinationsCount = GenerateCombinationsWithoutRepetitions(k, array, new List<int>(capacity: k), 1);
            int combinationsCount = GenerateCombinationsWithoutRepetitions(k, array, new bool[array.Length], new List<int>(capacity: k), 1);

            DateTime finish = DateTime.Now;
            TimeSpan elapsedTime = finish - start;

            Console.WriteLine($"Total combinations generated: {combinationsCount}");
            Console.WriteLine($"Elapsed time: {elapsedTime.TotalSeconds:f3}s");
        }

        static int GeneratePermutations(int[] array, bool[] used, List<int> slots, int initialId)
        {
            if (slots.Count == array.Length)
            {
                Console.WriteLine($"Permutation #{initialId}: {string.Join(", ", slots)}");
                return 1;
            }

            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (used[i]) continue;

                slots.Add(array[i]);
                used[i] = true;
                result += GeneratePermutations(array, used, slots, initialId + result);
                used[i] = false;
                slots.RemoveAt(slots.Count - 1);
            }

            return result;
        }

        static int GenerateCombinationsWithRepetitions(int k, int[] array, List<int> slots, int initialId)
        {
            if (slots.Count == k)
            {
                Console.WriteLine($"Combination #{initialId}: {string.Join(", ", slots)}");
                return 1;
            }

            int result = 0;
            for(int i = 0;i < array.Length;i++)
            {
                slots.Add(array[i]);
                result += GenerateCombinationsWithRepetitions(k, array, slots, result + initialId);
                slots.RemoveAt(slots.Count - 1);
            }

            return result;
        }

        //n = 1000, k = 3 => 55.108s
        static int GenerateCombinationsWithoutRepetitions(int k, int[] array, List<int> indices, int initialId)
        {
            if(indices.Count == k)
            {
                if (HasRepeatingElements(indices)) return 0;
                // Console.WriteLine($"Combination #{initialId}: {string.Join(", ", indices.Select(i => array[i]))}");
                return 1;
            }

            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                indices.Add(i);
                result += GenerateCombinationsWithoutRepetitions(k, array, indices, result + initialId);
                indices.RemoveAt(indices.Count - 1);
            }

            return result;
        }

        static bool HasRepeatingElements(List<int> list)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int el in list)
            {
                if (set.Contains(el)) return true;
                set.Add(el);
            }
            return false;
        }

        //n = 1000, k = 3 => 6.390s
        static int GenerateCombinationsWithoutRepetitions(int k, int[] array, bool[] used, List<int> slots, int initialId)
        {
            if (slots.Count == k)
            {
                // Console.WriteLine($"Combination #{initialId}: {string.Join(", ", slots)}");
                return 1;
            }

            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (used[i]) continue;

                slots.Add(array[i]);
                used[i] = true;
                result += GenerateCombinationsWithoutRepetitions(k, array, used, slots, result + initialId);
                used[i] = false;
                slots.RemoveAt(slots.Count - 1);
            }

            return result;
        }
    }
}
