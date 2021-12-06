using System;

namespace Esercizio12
{
    class Program
    {
        struct tools {
            public string code;
            public string description;
            public string category;
            public float price;
        }
        static void Main(string[] args)
        {
            int n = input("Inserisci il numero di elettrodomestici");
            tools[] tools = new tools[n];

            for (int i = 0; i < tools.Length; i++)
            {
                Console.WriteLine("Inserisci il codice dell'elettrodomestico " + (i + 1));
                tools[i].code = Console.ReadLine();
                Console.WriteLine("Inserisci la descrizione dell'elettrodomestico " + (i + 1));
                tools[i].description = Console.ReadLine();
                Console.WriteLine("Inserisci la categoria dell'elettrodomestico " + (i + 1));
                tools[i].category = Console.ReadLine();
                float price;
                do
                {
                    Console.WriteLine("Inserisci il prezzo dell'elettrodomestico " + (i + 1));
                    price = float.Parse(Console.ReadLine());
                } while (price < 0);
                tools[i].price = price;
            }

            do
            {
                switch(menu()) {
                    case 1:
                        Console.WriteLine("Inserisci il codice dell'elettrodomestico da cercare");
                        string code = Console.ReadLine();
                        printByCode(tools, code);
                        break;
                    case 2:
                        Console.WriteLine("Inserisci la categoria dell'elettrodomestico da cercare");
                        string category = Console.ReadLine();
                        printByCategory(tools, category);
                        break;
                    case 3:
                        printAveragePrice(tools);
                        break;
                    case 4:
                        return;
                }
            } while (true);
        }

        static int menu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Stampa i dati di un elettrodomestico");
            Console.WriteLine("2. Stampa i dati dell'elettrodomestico col prezzo più alto di una categoria");
            Console.WriteLine("3. Stampa il prezzo medio dei frigoriferi");
            Console.WriteLine("4. Esci");

            int n;
            do
            {
                n = input("Scegli un opzione");
            } while (n > 4);

            Console.WriteLine("\n\n");
            return n;
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

        // Funzione che trova un elettrodomestico per codice
        static void printByCode(tools[] tools, string code) {
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i].code == code)
                {
                    Console.WriteLine("Codice\tDescrizione\tCategoria\tPrezzo");
                    Console.WriteLine(tools[i].code + "\t" + tools[i].description + "\t" + tools[i].category + "\t" + tools[i].price);
                    return;
                }
            }
            Console.WriteLine("Non abbiamo trovato l'elettrodomestico con il codice " + code);
        }

        // Funzione che trova il prezzo massimo per una determinata categoria
        static void printByCategory(tools[] tools, string category) {
            float max = 0;
            int index = 0;
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i].category == category)
                {
                    if (tools[i].price > max)
                    {
                        max = tools[i].price;
                        index = i;
                    }
                }
            }
            if (max == 0)
            {
                Console.WriteLine("Non abbiamo trovato l'elettrodomestico con la categoria " + category);
            }
            else
            {
                Console.WriteLine("Codice\tDescrizione\tCategoria\tPrezzo");
                Console.WriteLine(tools[index].code + "\t" + tools[index].description + "\t" + tools[index].category + "\t" + tools[index].price);
            }
        }

        // Funzione che trova il prezzo medio dei frigoriferi
        static void printAveragePrice(tools[] tools) {
            float sum = 0;
            int count = 0;
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i].category == "frigorifero")
                {
                    sum += tools[i].price;
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Non abbiamo trovato nessun frigorifero");
            }
            else
            {
                Console.WriteLine("Il prezzo medio dei frigoriferi è " + (sum / count));
            }
        }
    }
}
