using System;


//Esercizio eseguito mentre si spiegava all'alunno Cucciati
namespace Esercizio6
{
    class Program
    {
        const int max = 100;
        static void Main(string[] args)
        {
            string[] nome = new string[max];
            double[] prezzo = new double[max];
            int[] quantita = new int[max];
            char[] categoria = new char[max];

            int elementi = caricaVet(nome, prezzo, quantita, categoria);
            prezzoMassimo(nome, prezzo, elementi);
            media(quantita, elementi);
            valorizzazione(prezzo, quantita, elementi);
            magazzino(categoria, prezzo, elementi);
            Console.ReadKey();
        }

        static int caricaVet(string[] nome, double[] prezzo, int[] quantita, char[] categoria) {
            int n;
            do
            {
                Console.WriteLine("Inserisci il numero di prodotti");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0 && n > 100);

            for (int i = 0; i < n; i++)
            {
                System.Console.WriteLine("Inserisci il nome del prodotto " + (i + 1));
                nome[i] = Console.ReadLine();
                System.Console.WriteLine("Inserisci il prezzo del prodotto " + (i + 1));
                prezzo[i] = double.Parse(Console.ReadLine());
                System.Console.WriteLine("Inserisci il quantita del prodotto " + (i + 1));
                quantita[i] = int.Parse(Console.ReadLine());
                do
                {
                    System.Console.WriteLine("Inserisci la categoria del prodotto " + (i + 1));
                    categoria[i] = Char.Parse(Console.ReadLine());
                } while (categoria[i] != 'A' && categoria[i] != 'B' && categoria[i] != 'C' && categoria[i] != 'D');
            }

            return n;
        }

        static void prezzoMassimo(string[] nome, double[] prezzo, int elementi) {
            double massimo = 0;
            int indice = 0;
            for (int i = 0; i < elementi; i++)
            {
                if(prezzo[i] > massimo){
                    massimo = prezzo[i];
                    indice = i;
                }
            }

            Console.WriteLine("Il prodotto " + nome[indice] + " ha il prezzo piu alto a: " + prezzo[indice]);
        }

        static void media(int[] quantita, int elementi) {
            double numero = 0;
            for (int i = 0; i < elementi; i++)
            {
                numero += quantita[i];
            }

            Console.WriteLine("La media della quantità è " + numero / elementi);
        }
    
        static void valorizzazione(double[] prezzo, int[] quantita, int elementi){
            double somma = 0;
            for (int i = 0; i < elementi; i++)
            {
                somma += prezzo[i] * quantita[i];
            }

            Console.WriteLine("La somma del prezzo di tutti i prodotti è uguale a" + somma);
        }

        static void magazzino(char[] categoria, double[] prezzo, int elementi) {

            double[] magazzini = new double[4];
            for (int i = 0; i < elementi; i++)
            {
                
                switch(categoria[i]) {
                    case 'A':
                        magazzini[0] += prezzo[i];
                        break;
                    case 'B':
                        magazzini[1] += prezzo[i];
                        break;
                    case 'C':
                        magazzini[2] += prezzo[i];
                        break;
                    case 'D':
                        magazzini[3] += prezzo[i];
                        break;
                }
            }

            System.Console.WriteLine("Il valore del magazzino A è " + magazzini[0]);
            System.Console.WriteLine("Il valore del magazzino B è " + magazzini[1]);
            System.Console.WriteLine("Il valore del magazzino C è " + magazzini[2]);
            System.Console.WriteLine("Il valore del magazzino D è " + magazzini[3]);
        }
    }
}
