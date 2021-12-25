using System;

namespace Lab3
{
    class Program
    {
        static int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        static int[] SelectionSort(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return SelectionSort(array, currentIndex + 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Сортування вибором");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Введіть елементи масиву: ");
            var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            Console.BackgroundColor = ConsoleColor.Green;
            var a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                a[i] = Convert.ToInt32(s[i]);
            }

            Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", SelectionSort(a)));
            Console.ReadLine();
        }
    }
}