using System;

namespace Esercizio3
{
    class Program
    {
        static void Main(string[] args)
        {
			char type;
			do
			{
				Console.WriteLine("Inserisci il tipo di triangolo ((E)quilatero, (I)soscele, (S)caleno)");
				type = char.Parse(Console.ReadLine());
			} while (type != 'I' && type != 'i' && type != 'E' && type != 'e' && type != 'S' && type != 's');

			// Classe dichiarata in https://github.com/spartacus04/CompitiInformatica2021-2022/blob/master/SecondoQuadrimestre/Esercizi/Esercizio3/triangolo.cs
			Triangle triangle = null;

			switch(type) {
				case 'E':
				case 'e':
					triangle = new Triangle(input("Inserisci la lunghezza di un lato"));
					break;

				case 'I':
				case 'i':
					triangle = new Triangle(input("Inserisci la lunghezza della base"), input("Inserisci la lunghezza dei 2 lati uguali"));
					break;

				case 'S':
				case 's':
					triangle = new Triangle(
						input("Inserisci la lunghezza del primo lato"),
						input("Inserisci la lunghezza del secondo lato"),
						input("Inserisci la lunghezza del terzo lato")
					);
					break;
			}

			Console.WriteLine("Il perimetro del triangolo è " + triangle.getPerimeter());
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
