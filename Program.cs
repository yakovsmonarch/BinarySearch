using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.Write("Задайте размер массива: ");
                int sizeArray = Convert.ToInt32(Console.ReadLine());
                int[] array = ArrayGenerator(sizeArray);
                Array.Sort(array);
                Print(array);

                Console.WriteLine();

                Console.Write("Число которое надо найти: ");
                int wantedNumber = Convert.ToInt32(Console.ReadLine());

                var positionNum = Search(array, wantedNumber);
                if(positionNum == null)
                {
                    Console.WriteLine("число не найдено");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine($"Позиция числа в массиве: {(int)positionNum}");

                Console.ReadKey();
            }
            
        }

        private static object Search(int[] array, int wantedNumber)
        {
            int minIndex = 0;
            int maxIndex = array.Length - 1;
            int centralIndex = 0;

            while ((maxIndex - minIndex) > 1)
            {
                centralIndex = (maxIndex - minIndex) / 2 + minIndex;
                if (array[centralIndex] == wantedNumber)
                    return centralIndex;
                if(wantedNumber < array[centralIndex])
                {
                    maxIndex = centralIndex;
                }
                if(wantedNumber > array[centralIndex])
                {
                    minIndex = centralIndex;
                }
            }
            if (wantedNumber == array[maxIndex])
                return maxIndex;
            if (wantedNumber == array[minIndex])
                return minIndex;
            
            return null;
        }

        private static int[] ArrayGenerator(int sizeArray)
        {
            Random rand = new Random();
            int[] nums = new int[sizeArray];
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(0, 100);
            }
            return nums;
        }

        private static void Print(int[] array)
        {
            foreach (int n in array)
            {
                Console.Write(n + " ");
            }
        }
    }
}
