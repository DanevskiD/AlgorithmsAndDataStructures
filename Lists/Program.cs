namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* // array that will be growing in time

             CustomList list = new CustomList();
             list.Add(1);
             list.Add(13);
             list.Add(7);
             list.Add(7);
             list.Add(7);
             list.Add(7);
             list.Add(7);

             Console.WriteLine(list[2]);

             list[5] = 100;
             Console.WriteLine(list[5]);

             Console.WriteLine($"Element at index 6 before insert: {list[6]}");
             list.Insert(6, 200);
             Console.WriteLine($"Element at index 6 after insert: {list[6]}");
             list.Insert(8, 300);

             Console.WriteLine($"List count before remove: {list.Count}");
             list.RemoveAt(0);
             Console.WriteLine($"List count after remove: {list.Count}");*/

            CustomDoublyLinkedList list = new CustomDoublyLinkedList();

            for (int i = 0; i < 10; i++) list.Add(i);

            Console.WriteLine(list.Count);

            for (int i = 0; i < 10; i++) list[i] += 5;

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Inserting element at index {i}");
                list.Insert(i, i * 2);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Value at index {i}: {list[i]}");
            }

            for (int i = 0;i < 3; i++) 
            {
                Console.WriteLine($"Removing element at index {0}");
                list.RemoveAt(0);

                Console.WriteLine($"Removing element at index {list.Count / 2}");
                list.RemoveAt(list.Count / 2);
                
                Console.WriteLine($"Removing element at index {list.Count - 1}");
                list.RemoveAt(list.Count - 1);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Value at index {i}: {list[i]}");
            }

            //IEnumerable
            Console.WriteLine(string.Join(", ", list));

            /* int elementsCount = list.Count;
            for(int i = 0; i < elementsCount; i++) list.RemoveAt(0); //graphs(BFS)

            // while (list.Count > 0) list.RemoveAt(0);  //queues, stacks

            Console.WriteLine($"List has {list.Count} elements left.");*/

            // 1. Access the value at index i
            // 2. Insert
            // 3. RemoveAt
            // 4. Use in loops
        }
    }
}
