using System;

namespace Compito3
{
    struct Participant {
        public string name;
        public string surname;
        public int[] scores;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int N = input("Inserisci il numero di partecipanti");
            Participant[] participants = new Participant[N];

            // Carica il vettore
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Inserisci i dati del partecipante numero " + (i + 1));
                Console.WriteLine("Inserisci il nome");
                participants[i].name = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome");
                participants[i].surname = Console.ReadLine();
                Console.WriteLine("Inserisci il punteggio dei 10 test");
                participants[i].scores = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    do
                    {
                        participants[i].scores[j] = input("1: ");
                    } while (participants[i].scores[j] > 20);
                }
            }

            // Stampa il punteggio medio di ogni partecipante
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < 10; j++)
                {
                    sum += participants[i].scores[j];
                }
                Console.WriteLine("Il punteggio medio di " + participants[i].name + " " + participants[i].surname + " è " + (sum / 10));
            }

            // Stampa il partecipante che ha il punteggio totale più alto
            int max = 0;
            int index = 0;
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < 10; j++)
                {
                    sum += participants[i].scores[j];
                }
                if (sum > max)
                {
                    max = sum;
                    index = i;
                }
            }

            Console.WriteLine("Il partecipante che ha vinto il concorso è " + participants[index].name + " " + participants[index].surname);

            // Stampa a video il punteggio migliore per ogni test
            for (int i = 0; i < 10; i++)
            {
                int sum = 0;
                int jndex = 0;
                for (int j = 0; j < N; j++)
                {
                    if (participants[j].scores[i] > sum)
                    {
                        sum = participants[j].scores[i];
                        jndex = j;
                    }
                }
                Console.WriteLine("Il punteggio migliore per il test " + (i + 1) + " è " + sum + " per " + participants[jndex].name + " " + participants[jndex].surname);
            }
        }

        static int input(string message) {
            int N;
            do
            {
                Console.WriteLine(message);
                N = int.Parse(Console.ReadLine());
            } while (N < 0);
            return N;
        }
    }
}
