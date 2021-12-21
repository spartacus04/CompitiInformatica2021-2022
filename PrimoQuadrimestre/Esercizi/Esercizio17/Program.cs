using System;

namespace Esercizio17
{
    class Program
    {
        struct Participant {
            public string surname;
            public string location;
            public int age;
            public int height;
            public int[] scores;
        }


        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Inserisci il numero di partecipanti: ");
                N = int.Parse(Console.ReadLine());
            } while (N < 0);
            Participant[] participants = new Participant[N];

            // carica il vettore
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Inserisci il cognome del partecipante: ");
                participants[i].surname = Console.ReadLine();
                Console.WriteLine("Inserisci la città di residenza del partecipante: ");
                participants[i].location = Console.ReadLine();
                do
                {
                    Console.WriteLine("Inserisci l'età del partecipante: ");
                    participants[i].age = int.Parse(Console.ReadLine());
                } while (participants[i].age < 0);
                Console.WriteLine("Inserisci la altezza del partecipante: ");
                participants[i].height = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci i punteggi del partecipante: ");
                participants[i].scores = new int[6];
                for (int j = 0; j < 6; j++)
                {
                    do
                    {
                        Console.WriteLine("Inserisci il punteggio " + (j + 1) + " del partecipante: ");
                        participants[i].scores[j] = int.Parse(Console.ReadLine());
                    } while (participants[i].scores[j] < 0 || participants[i].scores[j] > 10);   
                }
            }

            do
            {
                switch(menu()) {
                    case 1:
                        averageAgeByLocation(participants);
                        break;
                    case 2:
                        printParticipantBySurname(participants);
                        break;
                    case 3:
                        sortByAge(participants);
                        break;  
                    case 4:
                        heightThing(participants);
                        break;
                    case 5:
                        averageScore(participants);
                        break;
                    case 6:
                        return;
                }
            } while (true);
        }

        static int menu() {
            Console.WriteLine("\n\n1) Età media\n2) Stampa dati di un partecipante\n3) Ordinare per età\n4) Contare le ragazze che hanno una differenza di altezza delta maggiore di numero\n5) Calcolo punteggio medio\n6) Esci");

            int N;
            do
            {
                Console.WriteLine("Scegli un opzione");
                N = int.Parse(Console.ReadLine());
            } while (N < 0 || N > 6);
            Console.WriteLine("\n\n");
            return N;
        }
    
        static void averageAgeByLocation(Participant[] participants) {
            Console.WriteLine("Inserisci la città di residenza: ");
            string location = Console.ReadLine();
            int sum = 0;
            int count = 0;

            for (int i = 0; i < participants.Length; i++)
            {
                if (participants[i].location == location)
                {
                    sum += participants[i].age;
                    count++;
                }
            }

            if(count == 0) {
                Console.WriteLine("Non ho trovato partecipanti");
                return;
            }

            Console.WriteLine("Età media: " + (double)sum / count);
        }

        static void printParticipantBySurname(Participant[] participants) {
            Console.WriteLine("Inserisci il cognome: ");
            string surname = Console.ReadLine();

            for (int i = 0; i < participants.Length; i++)
            {
                if (participants[i].surname == surname)
                {
                    Console.WriteLine("Cognome: " + participants[i].surname);
                    Console.WriteLine("Città di residenza: " + participants[i].location);
                    Console.WriteLine("Età: " + participants[i].age);
                    Console.WriteLine("Altezza: " + participants[i].height);
                    Console.WriteLine("Punteggi: ");
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine("Punteggio " + (j + 1) + ": " + participants[i].scores[j]);
                    }
                }
            }
        }

        static void sortByAge(Participant[] participants) {
            Participant temp;
            for (int i = 0; i < participants.Length; i++)
            {
                for (int j = 0; j < participants.Length - 1; j++)
                {
                    if (participants[j].age > participants[j + 1].age)
                    {
                        temp = participants[j];
                        participants[j] = participants[j + 1];
                        participants[j + 1] = temp;
                    }
                }
            }

            // stampa i dati in una tabella
            Console.WriteLine("Cognome\tCittà\tEtà\tAltezza\tPunteggio1\tPunteggio2\tPunteggio3\tPunteggio4\tPunteggio5\tPunteggio6");
            for (int i = 0; i < participants.Length; i++)
            {
                Console.WriteLine(participants[i].surname + "\t" + participants[i].location + "\t" + participants[i].age + "\t" + participants[i].height + "\t" + participants[i].scores[0] + "\t" + participants[i].scores[1] + "\t" + participants[i].scores[2] + "\t" + participants[i].scores[3] + "\t" + participants[i].scores[4] + "\t" + participants[i].scores[5]);
            }
        }

        static void heightThing(Participant[] participants) {
            Console.WriteLine("Inserisci la differenza di altezza: ");
            int delta = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci l'altezza minima: ");
            int min = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < participants.Length; i++)
            {
                if (Math.Abs(participants[i].height - min) > delta)
                {
                    count++;
                }
            }

            Console.WriteLine("Numero di ragazze che hanno una differenza di altezza maggiore di " + delta + ": " + count);
        }

        static void averageScore(Participant[] participants) {
            for (int i = 0; i < participants.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < 6; j++)
                {
                    sum += participants[i].scores[j];
                }

                Console.WriteLine("Punteggio medio partecipante " + (i + 1) + ": " + (double)sum / 6);
            }
        }
    }
}
