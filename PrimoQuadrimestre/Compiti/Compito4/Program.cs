using System;

namespace Compito4
{
    class Program
    {
        struct Student {
            public string name;
            public string surname;
            public int grade;
        }
        static void Main(string[] args)
        {
            int N = input("Inserisci il numero di studenti");
            Student[] students = new Student[N];

            // Carica il vettore
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Inserisci il nomde dello studente " + (i + 1));
                students[i].name = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome dello studente " + (i + 1));
                students[i].surname = Console.ReadLine();
                do
                {
                    students[i].grade = input("Inserisci la media");
                } while (students[i].grade > 10);
            }

            // ordina il vettore in ordine decrescente
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    if (students[j].grade < students[j + 1].grade)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }

            // stampa la tabella
            Console.WriteLine("\n\nNome\tCognome\tVoto finale");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(students[i].name + "\t" + students[i].surname + "\t" + students[i].grade);
            }

            // Stampa la media della classe
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += students[i].grade;
            }

            Console.WriteLine("\nLa media della classe è" + (sum / N));

            // Stampare il nome e voto degli alunni maggiori della media e il loro numero
            Console.WriteLine("\nStudenti con voto maggiore della media");
            Console.WriteLine("Nome\tCognome\tVoto finale");
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                if (students[i].grade > (sum / N))
                {
                    Console.WriteLine("\n\n" + students[i].name + "\t" + students[i].surname + "\t" + students[i].grade);
                    count++;
                }
            }
            Console.WriteLine("\n\nNumero di studenti con voto maggiore della media: " + count);
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
    }
}
