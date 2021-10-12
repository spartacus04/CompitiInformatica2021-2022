using System;
using System.Linq;

namespace Esercizio7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] toSort = new int[100];
            loadArray(toSort);
            //toSort = new int[] { 10, 2, 4, 5};
            int[] sorted = sort(toSort);
            printArr(sorted);
        }

        static void printArr(int[] arr) {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void loadArray(int[] arr) {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            // Array casuale
            arr = arr.ToList().OrderBy(x => new Random().Next()).ToArray();
        }

        // Algoritmo di sorting dalla complessità 0(N^2)
        static int[] sort(int[] arr) {
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++) {
                    if(arr[j] < arr[i]) {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }
}