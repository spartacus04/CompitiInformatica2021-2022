using System;

namespace Esercizio15
{
    class Program
    {
        struct products {
            public string customerName;
            public int sold;
        }
        static void Main(string[] args)
        {
            int N = input("Inserisci il numero di prodotti");

            products[] prod = new products[N];

            for (int i = 0; i < prod.Length; i++)
            {
                Console.WriteLine("Insreisci il nome del cliente " + (i + 1));
                prod[i].customerName = Console.ReadLine();

                prod[i].sold = input("Inserisci il numero di prodotti venduti al cliente " + (i + 1));
            }

            do
            {
                switch(menu()) {
                    case 1:
                        averageAboveValue(prod, input("Inserisci un valore"));
                        break;
                    case 2:
                        maxSold(prod);
                        break;
                    case 3:
                        findSold(prod);
                        break;
                    case 4:
                        sortByName(prod);
                        break;
                    case 5:
                        return;
                }
            } while (true);
        }

        static int menu() {
            Console.WriteLine("\n\n1) Media delle vendite superiori a un valore\n2) Cliente con vendita massima\n3) Dato cliente trovare vendite\n4) Stampa clienti in ordine alfabetico");
            int n;
            do{
                n = input("Scegli un opzione");
            } while(n > 5);
            Console.WriteLine("\n\n");
            return n;
        }

        static int input(string message) {
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n < 0);
            return n;
        }

        static void averageAboveValue(products[] prod, int value) {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].sold > value)
                {
                    sum += prod[i].sold;
                    count++;
                }
            }
            Console.WriteLine("Media vendite superiori a " + value + ": " + (double)sum / count);
        }

        static void maxSold(products[] prod) {
            int max = 0;
            int index = 0;
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].sold > max)
                {
                    max = prod[i].sold;
                    index = i;
                }
            }
            Console.WriteLine("Cliente con vendita massima: " + prod[index].customerName);
        }

        static void findSold(products[] prod) {
            Console.WriteLine("Inserisci il nome del cliente");
            string name = Console.ReadLine();
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].customerName == name)
                {
                    Console.WriteLine("Vendite del cliente " + name + ": " + prod[i].sold);
                    return;
                }
            }
            Console.WriteLine("Cliente non trovato");
        }

        static void sortByName(products[] prod) {
            for (int i = 0; i < prod.Length; i++)
            {
                for (int j = i + 1; j < prod.Length; j++)
                {
                    if (prod[i].customerName.CompareTo(prod[j].customerName) > 0)
                    {
                        products temp = prod[i];
                        prod[i] = prod[j];
                        prod[j] = temp;
                    }
                }
            }
            for (int i = 0; i < prod.Length; i++)
            {
                Console.WriteLine("Cliente " + (i + 1) + ": " + prod[i].customerName);
            }
        }
    }
}
