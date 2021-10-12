using System;

namespace Esercizio8
{
    class Program
    {
        const int max = 100;
        static void Main(string[] args)
        {
            string[] city = new string[max];
            int[] temp = new int[max];

            int n = load(city, temp);
            sort(city, temp, n);

            System.Console.WriteLine("La temperatura minima è nella città di " + city[0] + " con temperatura " + temp[0]);
            System.Console.WriteLine("La temperatura massima è nella città di " + city[n - 1] + " con temperatura " + temp[n - 1]);
        }

        static int load(string[] city, int[] temp) {
            int n;
            do
            {
                System.Console.WriteLine("Inserisci il numero di città");
                n = int.Parse(Console.ReadLine());
            } while (n < 1 && n > max);

            for (int i = 0; i < n; i++)
            {
                System.Console.WriteLine("Inserisci il nome della città " + (i + 1));
                city[i] = Console.ReadLine();
                System.Console.WriteLine("Inserisci la temperatura della città " + (i + 1));
                temp[i] = int.Parse(Console.ReadLine());
            }
            return n;
        }

        static void sort(string[] city, int[] temp, int n) {
            for (int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++) {
                    if(temp[j] < temp[i]) {
                        int t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                        string t2 = city[i];
                        city[i] = city[j];
                        city[j] = t2;
                    }
                }
            }
        }        
    }
}
