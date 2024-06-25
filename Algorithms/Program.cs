namespace Algorithms
{
    internal class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            // if (BinarySearch(array, number)) Console.WriteLine($"{number} exists in the list.");
            // else Console.WriteLine($"{number} does not exist in the list.");

            int insertPosition = BinarySearchRightMostInsertPosition(array, number);
            Console.WriteLine($"{number} should be inserted at position {insertPosition}");
        }

        static bool Contains(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) return true;
            }

            return false;
        }

        static bool BinarySearch(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] == number) return true;

                if (array[middle] > number) high = middle - 1;
                else low = middle + 1;
            }

            return false;
        }

        static int BinarySearchInsertPosition(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] == number) return middle;

                if (array[middle] > number) high = middle - 1;
                else low = middle + 1;
            }

            return low;
        }

        static int BinarySearchLeftMostInsertPosition(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] >= number) high = middle - 1;
                else low = middle + 1;
            }

            return low;
        }

        static int BinarySearchRightMostInsertPosition(int[] array, int number)
        {
            int low = 0, high = array.Length - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;

                if (array[middle] > number) high = middle - 1;
                else low = middle + 1;
            }

            return high;
        }
    }
}
