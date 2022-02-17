using System;

namespace Esercizio5
{
    class Program
    {
        static void Main(string[] args)
        {
            double n;
            do {
		        Console.WriteLine("Inserisci la diagonale del quadrato");
		        n = double.Parse(Console.ReadLine());
            } while (n < 0);

            Square square = new Square(n);

	        Console.WriteLine(square.output());
	        Console.ReadKey();
        }
    }
}
