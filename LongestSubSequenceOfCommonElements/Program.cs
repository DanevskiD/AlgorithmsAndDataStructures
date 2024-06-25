using System.Xml;

namespace LongestSubSequenceOfCommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] dp = new int[array.Length];
            Array.Fill(dp, -1);

            int max = 0;
            for (int i = 0; i < array.Length; i++)
                max = Math.Max(max, CalculateMaxSubSequenceLength(i, array, dp));

            Console.WriteLine($"The longest sub-sequence has length {max}");
        }

        static int CalculateMaxSubSequenceLength(int index, int[] array, int[] dp)
        {
            if (dp[index] == -1)
            {
                int result = 0;

                for (int i = 0; i < index; i++)
                {
                    if (array[i] < array[index])
                        result = Math.Max(result, CalculateMaxSubSequenceLength(i, array, dp));
                }

                dp[index] = result + 1;
            }

            return dp[index];
        }
    }
}
