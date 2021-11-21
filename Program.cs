using System;

namespace task
{
    class Program
    {
        static int max_matrix(int[,] matrix, int n)
        {
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            int n = 0;

            bool check = false;

            while (check == false)
            {
                Console.Write("Введите n: ");

                string l = Console.ReadLine();

                if (int.TryParse(l, out n))
                {
                    check = true;
                }
            }

            int[,] matrix = new int[n, n];
            
            Random rnd = new Random();

            int k = rnd.Next(0, 100);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(0, 100);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"\t{matrix[i, j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"k = {k}");

            Console.WriteLine("Часть выше главной диагонали:");
            int up_min = max_matrix(matrix, n) + 1;
            string up_result = "В верхней части нет искомого элемента!";

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j >= i + 1; j--)
                {
                    if (matrix[i, j] % k == 0)
                    {
                        if (up_min > matrix[i, j])
                        {
                            up_min = matrix[i, j];
                            up_result = $"Искомый элемент верхней части равен [{i}, {j}] и равен {up_min}";
                        }
                    }
                    Console.Write($"{matrix[i, j]} ");
                }

                i += 1;

                for (int j = i + 1; j <= n - 1; j++)
                {
                    if (matrix[i, j] % k == 0)
                    {
                        if (up_min > matrix[i, j])
                        {
                            up_min = matrix[i, j];
                            up_result = $"Искомый элемент верхней части равен [{i}, {j}] и равен {up_min}";
                        }
                    }
                    Console.Write($"{matrix[i, j]} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine(up_result);

            Console.WriteLine("Главная диагональ:");
            int diagonal_max = -1;
            int diagonal_min = max_matrix(matrix, n) + 1;
            string diagonal_max_result = "";
            string diagonal_min_result = "";

            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write($"{matrix[i, i]} ");
                if (diagonal_max < matrix[i, i])
                {
                    diagonal_max = matrix[i, i];
                    diagonal_max_result = $"Максимальный искомый элемент на главной диагонали равен [{i}, {i}] и равен {diagonal_max}";
                }
                if (diagonal_min > matrix[i, i])
                {
                    diagonal_min = matrix[i, i];
                    diagonal_min_result = $"Минимальный искомый элемент на главной диагонали равен [{i}, {i}] и равен {diagonal_min}";
                }
            }
            Console.WriteLine();
            Console.WriteLine(diagonal_max_result);
            Console.WriteLine(diagonal_min_result);

            Console.WriteLine("Часть ниже главной диагонали:");
            int down_min = max_matrix(matrix, n) + 1;
            int down_max = -1;
            string down_max_result = "В нижней части нет искомого элемента!";

            double h = (diagonal_max - diagonal_min) / 2;
            Console.WriteLine($"Полу разница = {h}");

            if (h != 0)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    for (int i = j + 1; i <= n - 1; i++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                        if (matrix[i, j] % h == 0)
                        {
                            if (down_max < matrix[i, j])
                            {
                                down_max = matrix[i, j];
                                down_max_result = $"Максимальный искомый элемент нижней части равен [{i}, {j}] и равен {down_max}";

                            }
                        }
                    }

                    j += 1;

                    for (int i = n - 1; i >= j + 1; i--)
                    {
                        Console.Write($"{matrix[i, j]} ");
                        if (matrix[i, j] % h == 0)
                        {
                            if (down_max < matrix[i, j])
                            {
                                down_max = matrix[i, j];
                                down_max_result = $"Максимальный искомый элемент нижней части равен [{i}, {j}] и равен {down_max}";

                            }
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine(down_max_result);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка! Нет кратных нулю");
            }
        }
    }
}