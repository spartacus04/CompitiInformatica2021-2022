using System;

namespace Esercizio1
{
    class Program
    {
        static void Main(string[] args)
        {
	    int studentsLenght = input("Inserisci il numero di studenti");
            int vectorLenght = input("Inserisci la grandezza del vettore", studentsLenght);

            int[] studentsAge = new int[vectorLenght];
	    string toPrint = "";

            for(int i = 0; i < studentsLenght; i++){
		studentsAge[i] = input("Inserisci l'età dello studente numero " + (i + 1));
                if(studentsAge[i] >= 18){
		    toPrint += toPrint == "" ? i : ", " + i;
		}
            }

	    Console.WriteLine("\nGli alunni maggiorenni sono agli indici: " + toPrint);
	    Console.WriteLine("\nPremere un tasto per continuare");
	    Console.ReadKey();
        }

        static int input(string message, int min = 0){
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n <= min);
            return n;
        }
    }
}
