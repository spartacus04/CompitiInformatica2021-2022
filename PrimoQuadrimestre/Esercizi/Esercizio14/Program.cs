using System;

namespace Esercizio14
{
    class Program
    {
        struct Product {
            public string buyer { get; set; }
            public int day { get; set; }
            public int category { get; set; }
            public double value { get; set; }

            public Product(string buyer, int day, int category, double value) {
                this.buyer = buyer;
                this.day = day;
                this.category = category;
                this.value = value;
            }
        }

        static void Main(string[] args)
        {
            int n = input("Inserisci il numero di spese", 100);
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++) {
                Console.WriteLine("Inserisci il nome del compratore del prodotto " + (i + 1));
                string buyer = Console.ReadLine();
                int day = input("Inserisci il giorno della spesa" + (i + 1), 31);
                int category = input("Inserisci la categoria della spesa" + (i + 1), 9);
                double value;
                do
                {
                    Console.WriteLine("Inserisci il valore della spesa" + (i + 1));
                    value = double.Parse(Console.ReadLine());
                } while (value > 0);

                products[i] = new Product(buyer, day, category, value);
            }

            double total = getTotalSpend(products);

            do
            {
                switch(menu()) {
                    case 1:
                        Console.WriteLine("La spesa totale di madre è " + getTotalSpendByMother(products));
                        break;
                    case 2:
                        int category = input("Inserisci il nome della categoria", 9);
                        double totalSpend = getTotalSpendByCategory(products, category);
                        double percent = (totalSpend / total) * 100;
                        Console.WriteLine("La spesa totale di " + category + " è " + totalSpend + " che è " + percent + "% della spesa totale");
                        break;
                    case 3:
                        spentDayByDay(products);
                        break;
                    case 4:
                        maxSpentByDay(products);
                        break;
                    case 5:
                        maxSpentByCategory(products);
                        break;
                    case 6:
                        minSpentByCategory(products, total);
                        break;
                    case 7:
                        return;
                }
            } while (true);
        }

        static int menu() {
            Console.WriteLine("\n\n");
            Console.WriteLine("1) Visualizza le spese di madre");
            Console.WriteLine("2) Visualizza la spesa totale di una categoria e la percentuale sulla spesa totale");
            Console.WriteLine("3) Visualizza la spesa giornaliera di ogni giorno");
            Console.WriteLine("4) Visualizza il giorno con maggior numero di acquisti");
            Console.WriteLine("5) Visualizza la categoria con maggiori acquisti");
            Console.WriteLine("6) Visualizza la categoria con spesa minore");
            Console.WriteLine("7) Esci");

            int n = input("Scegli un opzione", 7);
            Console.WriteLine("\n\n");
            return n;
        }

        static int input(string message, int max) {
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > max);
            return n;
        }

        // funzione che calcola la spesa totale di compratore "madre"
        static double getTotalSpendByMother(Product[] products) {
            double totalSpend = 0;
            for (int i = 0; i < products.Length; i++) {
                if (products[i].buyer == "madre") {
                    totalSpend += products[i].value;
                }
            }
            return totalSpend;
        }

        static double getTotalSpendByCategory(Product[] products, int category) {
            double totalSpend = 0;
            for (int i = 0; i < products.Length; i++) {
                if (products[i].category == category) {
                    totalSpend += products[i].value;
                }
            }
            return totalSpend;
        }
        
        // Funzione che calcola la spesa totale
        static double getTotalSpend(Product[] products) {
            double totalSpend = 0;
            for (int i = 0; i < products.Length; i++) {
                totalSpend += products[i].value;
            }
            return totalSpend;
        }

        // funzione che stampa a video la spesa totale giorno per giorno
        static void spentDayByDay(Product[] products) {
            int[] days = new int[31];
            for (int i = 0; i < products.Length; i++) {
                days[products[i].day - 1] += 1;
            }

            for (int i = 0; i < days.Length; i++) {
                Console.WriteLine("Il giorno " + (i + 1) + " ha " + days[i] + " acquisti");
            }
        }

        static void maxSpentByDay(Product[] products) {
            double[] maxSpend = new double[31];
            for (int i = 0; i < products.Length; i++) {
                if (products[i].value > maxSpend[products[i].day - 1]) {
                    maxSpend[products[i].day - 1] = products[i].value;
                }
            }

            double max = maxSpend[0];
            int maxSpentIndex = 0;
            for (int i = 0; i < maxSpend.Length; i++) {
                if (maxSpend[i] > max) {
                    max = maxSpend[i];
                    maxSpentIndex = i;
                }
            }

            Console.WriteLine("Il giorno " + (maxSpentIndex + 1) + " ha la spesa massima di " + max);
        }

        static void maxSpentByCategory(Product[] products) {
            double[] maxSpend = new double[9];

            for (int i = 0; i < products.Length; i++) {
                if (products[i].value > maxSpend[products[i].category - 1]) {
                    maxSpend[products[i].category - 1] = products[i].value;
                }
            }

            double max = maxSpend[0];
            int maxSpentIndex = 0;
            for (int i = 0; i < maxSpend.Length; i++) {
                if (maxSpend[i] > max) {
                    max = maxSpend[i];
                    maxSpentIndex = i;
                }
            }

            Console.WriteLine("La categoria " + (maxSpentIndex + 1) + " ha la spesa massima di " + max);
        }

        //quale e&#39; la categoria merceologica, tra quelle che hanno avuto almeno una voce di spesa, con il valore percentuale piu basso
        static void minSpentByCategory(Product[] products, double totalSpend) {
            double[] minSpend = new double[9];

            for (int i = 0; i < products.Length; i++) {
                if (products[i].value < minSpend[products[i].category - 1]) {
                    minSpend[products[i].category - 1] = products[i].value;
                }
            }

            double min = minSpend[0];
            int minSpentIndex = 0;

            for (int i = 0; i < minSpend.Length; i++) {
                if (minSpend[i] < min) {
                    min = minSpend[i];
                    minSpentIndex = i;
                }
            }

            Console.WriteLine("La categoria " + (minSpentIndex + 1) + " ha la spesa minore di " + min + " che è " + (min / totalSpend) * 100 + "% della spesa totale");
        }
    }
}
