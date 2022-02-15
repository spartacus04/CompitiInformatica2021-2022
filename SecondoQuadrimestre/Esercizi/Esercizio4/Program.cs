using System;

namespace Esercizio4
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1;
			do{
				Console.WriteLine("Inserisci il raggio del primo cerchio");
				n1 = double.Parse(Console.ReadLine());
			}while(n1 < 0);

			double n2;
			do
			{
				Console.WriteLine("Inserisci il raggio del secondo cerchio");
				n2 = double.Parse(Console.ReadLine());
			} while (n2 < 0);

			Console.WriteLine("\n\n");

			Circle c1 = new Circle(n1);
			Circle c2 = new Circle(n2);

			Console.WriteLine(c1.Output());
			Console.WriteLine(c2.Output());

			if(c1.GetArea() > c2.GetArea()) {
				Console.WriteLine("Il primo cerchio ha un area maggiore");
			} else if(c1.GetArea() < c2.GetArea()) {
				Console.WriteLine("Il secondo cerchio ha un area maggiore");
			} else {
				Console.WriteLine("I due cerchi hanno la stessa area");
			}
        }
    }
}
