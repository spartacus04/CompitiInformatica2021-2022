using System;

namespace Esercizio11
{
    class Program
    {
        struct worker
        {
            public string name;
            public string surname;
            public int age;
            public double salary;
        }

        static void Main(string[] args)
        {
            int n = input("Inserisci il numero di lavoratori");

            worker[] w = new worker[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Inserisci il nome del lavoratore " + (i + 1));
                w[i].name = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome del lavoratore " + (i + 1));
                w[i].surname = Console.ReadLine();
                w[i].age = input("Inserisci l'età del lavoratore " + (i + 1));
                do
                {
                    Console.WriteLine("Inserisci il salario del lavoratore " + (i + 1));
                    w[i].salary = float.Parse(Console.ReadLine());
                } while (w[i].salary <= 0);
            }

            do
            {
                switch(menu())
                {
                    case 1:
                        int age = input("Inserisci l'età massima dei lavoratori");
                        printWorkersByAge(w, age);
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il nome del lavoratore");
                        string surname = Console.ReadLine();
                        printWorkerBySurname(w, surname);
                        break;
                    case 3:
                        int surnamesLenght = input("Inserisci la lunghezza massima dei cognomi");
                        string[] surnames = new string[surnamesLenght];
                        for (int i = 0; i < surnamesLenght; i++)
                        {
                            Console.WriteLine("Inserisci il cognome " + (i + 1));
                            surnames[i] = Console.ReadLine();
                        }
                        increaseSalary(w, surnames);
                        break;
                    case 4:
                        return;
                }
            } while (true);
        }

        static int menu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Stampa l'elenco dei lavoratori sotto una certa soglia di età");
            Console.WriteLine("2. Stampa il dettaglio di un lavoratore");
            Console.WriteLine("3. Aumenta lo stipendio di lavoratori dato il cognome");
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

        // funzione che stampa una tabella di lavoratori sotto una certa soglia di eta
        static void printWorkersByAge(worker[] w, int age)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Lavoratori sotto una certa soglia di età");
            Console.WriteLine("\n");
            Console.WriteLine("Nome\t\tCognome\t\tEtà\t\tStipendio");
            Console.WriteLine("\n");
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].age < age)
                {
                    Console.WriteLine(w[i].name + "\t\t" + w[i].surname + "\t\t" + w[i].age + "\t\t" + w[i].salary);
                }
            }
        }

        // Funzione che stampa i dati di un lavoratore dato il suo cognome
        static void printWorkerBySurname(worker[] w, string surname)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Dettaglio del lavoratore");
            Console.WriteLine("\n");
            Console.WriteLine("Nome\t\tCognome\t\tEtà\t\tStipendio");
            Console.WriteLine("\n");
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].surname == surname)
                {
                    Console.WriteLine(w[i].name + "\t\t" + w[i].surname + "\t\t" + w[i].age + "\t\t" + w[i].salary);
                }
            }
        }

        // Funzione che aumenta lo stipendio di tutti i lavoratori con dei certi cognomi
        static void increaseSalary(worker[] w, string[] surnames)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Lavoratori con dei certi cognomi");
            Console.WriteLine("\n");
            Console.WriteLine("Nome\t\tCognome\t\tEtà\t\tStipendio");
            Console.WriteLine("\n");
            for (int i = 0; i < w.Length; i++)
            {
                for (int j = 0; j < surnames.Length; j++)
                {
                    if (w[i].surname == surnames[j])
                    {
                        w[i].salary += w[i].salary * 0.1;
                        Console.WriteLine(w[i].name + "\t\t" + w[i].surname + "\t\t" + w[i].age + "\t\t" + w[i].salary);
                    }
                }
            }
        }

    }
}
