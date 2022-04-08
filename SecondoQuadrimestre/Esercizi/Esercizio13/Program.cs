using System;

namespace Esercizio13
{
    class Program
    {
        static void Main(string[] args)
        {
			Dispenser dispenser = new Dispenser(1, "dispenser", 10, true, 10);
			dispenser.reload(5);
			Console.WriteLine(dispenser.sell());

			dispenser.Enabled = false;

			dispenser.repair();

			cumulativeDispenser cumulativeDispenser = new cumulativeDispenser(2, "cumulativeDispenser", 10, true, 10);

			Console.WriteLine(cumulativeDispenser.sell(5));
        }
    }
}
