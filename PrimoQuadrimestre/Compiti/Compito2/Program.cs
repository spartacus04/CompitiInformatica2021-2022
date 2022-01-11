using System;

namespace Compito2
{
    struct Booking {
        public string name;
        public string surname;
        public int day;
        public string type;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int N = input("Inserisci il numero di prenotazioni", 1000);
            Booking[] bookings = new Booking[N];

            // Carica il vettore
            for (int i = 0; i < N; i++)
            {
                System.Console.WriteLine("Inserisci il nome " + (i + 1));
                bookings[i].name = Console.ReadLine();
                System.Console.WriteLine("Inserisci il cognome " + (i + 1));
                bookings[i].surname = Console.ReadLine();
                bookings[i].day = input("Inserisci il giorno", 31);
                System.Console.WriteLine("Inserisci il tipo di operazione " + (i + 1));
                bookings[i].type = Console.ReadLine();
            }

            // Stampa i giorni liberi
            int[] days = new int[31];
            for(int i = 0; i < N; i++) {
                days[bookings[i].day - 1]++;
            }
            for (int i = 0; i < days.Length; i++)
            {
                if(days[i] == 0)
                    Console.WriteLine("Il giorno " + (i + 1) + " è libero");
                else
                    Console.WriteLine("Il giorno " + (i + 1) + " ha " + days[i] + " prenotazioni");
            }

        }

        static int input(string message, int max) {
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n <= 0 || n > max);
            return n;
        }
    }
}
