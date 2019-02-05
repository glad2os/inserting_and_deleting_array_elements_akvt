using System;
using System.Linq;

namespace arrays_2
{
    internal static class Program
    {
        private static int[] input_Massive(int n)
        {
            return new int[n];
        }

        private static int count_array()
        {
            int n = 0;
            Console.Write("Введите кол-во элементов массива: ");
            while (n <= 0) n = int.Parse(Console.ReadLine());
            return n;
        }

        private static void output_mass(int[] massive)
        {
            foreach (var t in massive) Console.Write(t + " ");
            Console.Write("\n");
        }

        private static int[] who_will_update_mass(int[] massive, int n, int user)
        {
            if (user == 0) massive = update_mass_by_user(massive, n);
            else
            {
                int first, second;
                Range(out first, out second);
                massive = update_random_int(massive, n, first, second);
            }

            return massive;
        }

        private static void Range(out int first, out int second)
        {
            Console.Write("Введите мин значение:");
            first = int.Parse(Console.ReadLine());
            Console.Write("Введите макс значение:");
            second = int.Parse(Console.ReadLine());

            if (first <= second) return;

            first ^= second;
            second ^= first;
            first ^= second;
        }

        static int[] update_mass_by_user(int[] massive, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите {0}эл. м. ", i + 1);
                massive[i] = int.Parse(Console.ReadLine());
            }

            return massive;
        }

        static int[] update_random_int(int[] massive, int n, int first, int second)
        {
            if (massive == null) throw new ArgumentNullException("massive");
            massive = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                massive[i] = rnd.Next(first, second);
            }

            return massive;
        }

        private static int find_max_in_array(int[] array, int n)
        {
            var max = 0;
            for (var i = 0; i < n; i++) if (array[i] > max) max = array[i];
            return max;
        }

        /**
         * Удалить из массива все двузначные числа. Элементы, удаляемые из массива поместить во второй массив. ✓
         */
        private static int[] first_task(ref int[] array)
        {
            var output = array.Where(i => Math.Abs(i) > 9 && Math.Abs(i) < 100).ToArray();
            array = array.Where(i => Math.Abs(i) < 10 || Math.Abs(i) > 99).ToArray();
            return output;
        }

        /**
         * Вставить после каждого положительного элемента второго массива максимальный элемент из первого массива ✓
         */
        private static int[] second_task(int[] array, ref int[] array2)
        {
            int max = find_max_in_array(array, array.Length);
            int counter = 0;
            foreach (var i in array2) if (i > 0) ++counter;
            int[] output = new int[array2.Length + counter];
            int k = 0;
            foreach (var i in array2)
            {
                output[k++] = i;
                if (i > 0) output[k++] = max;
            }
            // max = 4
            // -3 -2 -1 0 1 2 3
            // -3 -2 -1 0 1 4 2 4 3 4
            array2 = output;
            return output;
        }

            
        public static void Main(string[] args)
        {
            Console.Write("Кто будет заполнять массив?\n0 - user , 1 - random: ");
            int user = int.Parse(Console.ReadLine());
            int n = count_array();
            int[] mass = input_Massive(n);
            mass = who_will_update_mass(mass, n, user);
            output_mass(mass);
            var firstTask = first_task(ref mass);
            Console.WriteLine("first");
            output_mass(mass);
            output_mass(firstTask);
            second_task(mass, ref firstTask);
            Console.WriteLine("second");
            output_mass(firstTask);
            
            
        }

    }
}