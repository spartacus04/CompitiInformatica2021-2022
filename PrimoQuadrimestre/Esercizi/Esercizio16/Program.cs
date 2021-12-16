using System;

namespace Esercizio16
{
    class Program
    {   
        struct Hotel { 
            public string code;
            public string name;
            public string city;
            public int available;
        }
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("Inserisci il numero di hotel da inserire:");
                n = int.Parse(Console.ReadLine());
            } while (n < 0);

            Hotel[] hotels = new Hotel[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Inserisci il codice dell'hotel " + (i + 1) + ":");
                hotels[i].code = Console.ReadLine();
                Console.WriteLine("Inserisci il nome dell'hotel " + (i + 1) + ":");
                hotels[i].name = Console.ReadLine();
                Console.WriteLine("Inserisci la città dell'hotel " + (i + 1) + ":");
                hotels[i].city = Console.ReadLine();
                do
                {
                    Console.WriteLine("Inserisci il numero di camere disponibili nell'hotel " + (i + 1) + ":");
                    hotels[i].available = int.Parse(Console.ReadLine());
                } while (hotels[i].available < 0);
            }

            do
            {
                switch(menu()) {
                    case 1:
                        bookHotel(hotels);
                        break;
                    case 2:
                        break;
                    case 3:
                        return;
                }
            } while (true);
        }

        static int menu() {
            Console.WriteLine("\n\n1) Prenota un hotel\n2) Valuta prenotazioni\n3) Esci");
            int n;
            do
            {
                Console.WriteLine("Scegli un opzione");
                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > 3);
            return n;
        }

        static void bookHotel(Hotel[] hotels) {
            Console.WriteLine("Vuoi cercare un hotel per nome o per città?");
            Console.WriteLine("1) Nome\n2) Città");
            int n;
            do
            {
                Console.WriteLine("Scegli un opzione");
                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > 2);

            if(n == 1) {
                searchByName(hotels);
            }
            else {
                searchByCity(hotels);
            }
        }

        static void searchByName(Hotel[] hotels) {
            Console.WriteLine("Inserisci il nome dell'hotel da cercare:");
            string name = Console.ReadLine();
            for (int i = 0; i < hotels.Length; i++)
            {
                if (hotels[i].name == name)
                {
                    if(hotels[i].available > 1) {
                        Console.WriteLine("Hotel prenotato:");
                        Console.WriteLine("Codice: " + hotels[i].code);
                        Console.WriteLine("Nome: " + hotels[i].name);
                        Console.WriteLine("Città: " + hotels[i].city);
                        Console.WriteLine("Camere disponibili: " + hotels[i].available);
                        hotels[i].available--;
                        return;
                    }
                }
            }
            Console.WriteLine("Hotel non trovato");
        }

        static void searchByCity(Hotel[] hotels) {
            Console.WriteLine("Inserisci la città da cercare:");
            string city = Console.ReadLine();
            for (int i = 0; i < hotels.Length; i++)
            {
                if (hotels[i].city == city)
                {
                    if(hotels[i].available > 1) {
                        Console.WriteLine("Hotel prenotato:");
                        Console.WriteLine("Codice: " + hotels[i].code);
                        Console.WriteLine("Nome: " + hotels[i].name);
                        Console.WriteLine("Città: " + hotels[i].city);
                        Console.WriteLine("Camere disponibili: " + hotels[i].available);
                        hotels[i].available--;
                        return;
                    }
                }
            }
            Console.WriteLine("Hotel non trovato");
        }

        static void checkAvaibility(Hotel[] hotels) {
            int n;
            do
            {
                Console.WriteLine("Inserisci il numero di prenotazioni");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            Console.WriteLine("Inserisci il nome della località");
            string city = Console.ReadLine();

            for (int i = 0; i < hotels.Length; i++)
            {
                if (hotels[i].city == city)
                {
                    if (hotels[i].available >= n)
                    {
                        Console.WriteLine("Hotel disponibile:");
                        Console.WriteLine("Codice: " + hotels[i].code);
                        Console.WriteLine("Nome: " + hotels[i].name);
                        Console.WriteLine("Città: " + hotels[i].city);
                        Console.WriteLine("Camere disponibili: " + hotels[i].available);
                        if(hotels[i].available >= n) {
                            Console.WriteLine("Posti da prenotare: " + n);
                            n = 0;
                        }
                        else {
                            Console.WriteLine("Posti da prenotare: " + hotels[i].available);
                            n -= hotels[i].available;
                        }
                        
                        if(n == 0) {
                            break;
                        }
                    }
                }
            }
            
        }
    }
}
