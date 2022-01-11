using System;

namespace Compito1
{
    struct Product {
        public string name;
        public string description;
        public int size;
        public double price;
        public int year;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int N = input("Inserisci il numero di prodotti");
            Product[] products = new Product[N];
            int[] toDelete = new int[0];

            // Carica i dati dei prodotti
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Inserisci il nome del prodotto"  + (i + 1));
                products[i].name = Console.ReadLine();
                Console.WriteLine("Inserisci la descrizione del prodotto " + (i + 1));
                products[i].description = Console.ReadLine();
                products[i].size = input("Inserisci la dimensione del prodotto " + (i + 1));
                products[i].price = inputDouble("Inserisci il prezzo del prodotto " + (i + 1));
                products[i].year = input("Inserisci l'anno di produzione del prodotto " + (i + 1));
                if(products[i].year <= 2021) {
                    toDelete = dynamicArr(toDelete, i);
                }
            }

            // Cancella i prodotti vecchi con shift elementi
            for (int i = 0; i < toDelete.Length; i++)
            {
                for (int j = toDelete[i]; j < N - 1; j++)
                {
                    products[j] = products[j + 1];
                }
            }

            // Stampa il valore complessivo dei prodotti rimanenti
            double total = 0;
            for (int i = 0; i < N - toDelete.Length; i++)
            {
                total += products[i].price * products[i].size;
            }
            Console.WriteLine("Il valore complessivo dei prodotti rimanenti è " + total);

            // Stampa in una tabella i prodotti rimanenti
            Console.WriteLine("\n\nNome\tDescrizione\t\tNumero\tPrezzo\tAnno");
            for (int i = 0; i < N - toDelete.Length; i++)
            {
                Console.WriteLine(products[i].name + "\t" + products[i].description + "\t\t\t" + products[i].size + "\t" + products[i].price + "\t" + products[i].year);
            }

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

        static double inputDouble(string message) {
            double n;
            do
            {
                Console.WriteLine(message);
                n = double.Parse(Console.ReadLine());
            } while (n <= 0);
            return n;
        }

        static int[] dynamicArr(int[] arr, int toAdd) {
            int[] newArr = new int[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            newArr[newArr.Length - 1] = toAdd;
            return newArr;
        }
    }
}
