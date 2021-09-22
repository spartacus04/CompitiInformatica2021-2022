using System;

namespace Esercizio5
{
    class Program
    {
        //Ricerca elemento in un array
        //Dato il nome di un concorrente trova la sua posizione in classifica
        static void Main(string[] args)
        {
            int n = input("Inserisci il numero di concorrenti");

            string[] names = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Inserisci il nome del concorrente alla posizione " + (i + 1));
                names[i] = Console.ReadLine();
            }

            Console.WriteLine("Inserisci il nome da cercare");
            string nameToFind = Console.ReadLine();

            int index = findByElement(names, nameToFind);

            if(index < 0){
                Console.WriteLine("Non esiste un partecipante con quel nome");
                return;
            }

            Console.WriteLine("Il concorrente " + nameToFind + " si trova alla posizione " + (index + 1));
            Console.ReadKey();
        }

        static int findByElement(string[] arr, string n){
            //return Array.FindIndex(arr, x => x == n);
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == n)
                    return i;
            }
            return -1;
        }

        static int input(string message){
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n < 0);
            return n;
        }
    }
}
