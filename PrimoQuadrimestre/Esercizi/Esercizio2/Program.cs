using System;

namespace Esercizio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = input("Inserisci la grandezza del vettore");
            int[] arr = new int[n];
            bool isEven = true;
            int even = 0, odd = 0;

            for (int i = 0; i < n; i++)
            {
                arr[i] = input("Inserisci un numero per l'indice " + i);
                if(isEven){
                    even += arr[i];
                }
                else
                {
                    odd += arr[i];
                }
                isEven = !isEven;
            }

            Console.WriteLine("I la sommma dei numeri pari è " + even);
            Console.WriteLine("I la sommma dei numeri dispari è " + odd);
            Console.ReadKey();
        }

        static int input(string message) {
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            return n;
        }
    }
}
