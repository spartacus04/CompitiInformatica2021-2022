using System;

namespace Esercizio9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = input("Inserisci il numero di studenti");
            string[] nomi = new string[n];
            int[] voti = new int[n];
            int[] classi = new int[n];

            // Carico i vettori
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Inserisci il nome dello studente numero " + (i + 1));
                nomi[i] = Console.ReadLine();
                voti[i] = input("Inserisci il voto dello studente " + nomi[i]);
                classi[i] = input("Inserisci la classe dello studente " + nomi[i]);
            }

            do
            {
                switch(menu()) {
                    case 1:
                        bubbleSortByName(nomi, voti, classi);
                        printTable(nomi, voti, classi);
                        break;
                    case 2:
                        bubbleSortByClass(nomi, voti, classi);
                        printTable(nomi, voti, classi);
                        break;
                    case 3:
                        Ricerca(nomi, voti, classi);
                        break;
                    case 4:
                        return;

                }
            } while (true);
        }

        // Funzione che stampa un menu e restituisce la scelta dell'utente
        static int menu()
        {
            Console.Write("\n\n\n");
            Console.WriteLine("1. Visualizza studenti ordinati per nome");
            Console.WriteLine("2. Visualizza studenti ordinati per classe");
            Console.WriteLine("3. Cerca uno studente e visualizza i suoi dati");
            Console.WriteLine("4. Esci");
            int s;
            do
            {
                s = input("Scegli un'opzione");
            } while (s > 4);
            Console.Write("\n\n\n");
            return s;
        }

        static int input(string message)
        {
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            return n;
        }

        static void printTable(string[] nomi, int[] voti, int[] classi)
        {
            Console.WriteLine("Nome\tVoto\tClasse");
            for (int i = 0; i < nomi.Length; i++)
            {
                Console.WriteLine(nomi[i] + "\t" + voti[i] + "\t" + classi[i]);
            }
        }
    
        // Funzione per ordinare in ordine alfabetico usando bubblesort
        static void bubbleSortByName(string[] nomi, int[] voti, int[] classi)
        {
            for (int i = 0; i < nomi.Length; i++)
            {
                for (int j = 0; j < nomi.Length - 1; j++)
                {
                    if (nomi[j].CompareTo(nomi[j + 1]) > 0)
                    {
                        string temp = nomi[j];
                        nomi[j] = nomi[j + 1];
                        nomi[j + 1] = temp;

                        int temp2 = voti[j];
                        voti[j] = voti[j + 1];
                        voti[j + 1] = temp2;

                        int temp3 = classi[j];
                        classi[j] = classi[j + 1];
                        classi[j + 1] = temp3;
                    }
                }
            }
        }

        // Funzione per ordinare per classi usando bubblesort
        static void bubbleSortByClass(string[] nomi, int[] voti, int[] classi)
        {
            for (int i = 0; i < classi.Length; i++)
            {
                for (int j = 0; j < classi.Length - 1; j++)
                {
                    if (classi[j] > classi[j + 1])
                    {
                        string temp = nomi[j];
                        nomi[j] = nomi[j + 1];
                        nomi[j + 1] = temp;

                        int temp2 = voti[j];
                        voti[j] = voti[j + 1];
                        voti[j + 1] = temp2;

                        int temp3 = classi[j];
                        classi[j] = classi[j + 1];
                        classi[j + 1] = temp3;
                    }
                }
            }
        }

        // Funzione per cercare uno studente usando la ricerca binaria
        static void Ricerca(string[] nomi, int[] voti, int[] classi)
        {
            Console.WriteLine("Inserisci il nome dello studente da cercare");
            string nome = Console.ReadLine();
            int pos = binarySearch(nomi, nome);
            if (pos == -1)
            {
                Console.WriteLine("Lo studente non è stato trovato");
            }
            else
            {
                Console.WriteLine("Lo studente è stato trovato nella posizione " + pos);
                Console.WriteLine("Il suo voto è " + voti[pos]);
                Console.WriteLine("La sua classe è " + classi[pos]);
            }
        }

        // Funzione che restituisce la posizione dello studente nella lista
        static int binarySearch(string[] nomi, string nome)
        {
            int left = 0;
            int right = nomi.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (nomi[middle].CompareTo(nome) < 0)
                {
                    left = middle + 1;
                }
                else if (nomi[middle].CompareTo(nome) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}
