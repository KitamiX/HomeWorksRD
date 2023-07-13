using System.Diagnostics;

namespace Homework9_GenericType_
{
    internal class Program
    {
        public static int[] GenerateRandomNumber(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);

            return array;
        }
        public static int[] BubbleSort(int[] NumArray)
        {
            var n = NumArray.Length;
            bool swapRequired;

            for (int i = 0; i < n - 1; i++)
            {
                swapRequired = false;
                for (int j = 0; j < n - i - 1; j++)
                    if (NumArray[j] > NumArray[j + 1])
                    {
                        var tempVar = NumArray[j];
                        NumArray[j] = NumArray[j + 1];
                        NumArray[j + 1] = tempVar;
                        swapRequired = true;
                    }
                if (swapRequired == false)
                    break;
            }

            return NumArray;
        }
        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
        }
        private static IEnumerable<T> BubbleSortGeneric<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            T[] sortedList = list.ToArray();
            int listLength = sortedList.Length;
            while (true)
            {
                bool performedSwap = false;
                for (int currentItemIndex = 1; currentItemIndex < listLength; currentItemIndex++)
                {
                    int previousItemIndex = currentItemIndex - 1;
                    T previousItem = sortedList[previousItemIndex];
                    T currentItem = sortedList[currentItemIndex];
                    var comparison = previousItem.CompareTo(currentItem);
                    if (comparison > 0)
                    {
                        sortedList[previousItemIndex] = currentItem;
                        sortedList[currentItemIndex] = previousItem;
                        performedSwap = true;
                    }
                }

                if (!performedSwap)
                {
                    break;
                }
            }

            return sortedList;
        }

        private static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
        }
        static void Main(string[] args)
        {
            var size = 10000;
            var arr = GenerateRandomNumber(size);
            Stopwatch st1 = new Stopwatch();
            Stopwatch st2 = new Stopwatch();
            PrintArray(arr);
            st1.Start();
            var sortedNumbers = BubbleSort(arr);
            st1.Stop();
            PrintArray(sortedNumbers);
            st2.Start();
            var sortedNumbersGeneric = BubbleSortGeneric(arr);
            st2.Stop();
            PrintList(sortedNumbersGeneric);
            Console.WriteLine() ;
            Console.WriteLine("\n Not Generic Time: " + st1.Elapsed.TotalNanoseconds + " ns"); // 90615200 ns (5k elements)  ; 370631400 ns (10k elements) 
            Console.WriteLine("\n Generic Type Time: "  + st2.Elapsed.TotalNanoseconds + " ns"); // 1224200 ns (5k elements) ; 1198600 ns (10k elements)
        }
    }
}