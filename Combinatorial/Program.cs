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
            // int combinationsCount = GenerateCombinationsWithRepetitions(k, array, new List<int>(capacity: k), 1);
             int combinationsCount = GenerateCombinationsWithoutRepetitions(k, array, new bool[array.Length], new List<int>(capacity: k), 1);

            Console.WriteLine($"Total combinations generated: {combinationsCount}");
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

        static int GenerateCombinationsWithoutRepetitions(int k, int[] array, bool[] used, List<int> slots, int initialId)
        {
            if (slots.Count == k)
            {
                Console.WriteLine($"Combination #{initialId}: {string.Join(", ", slots)}");
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
