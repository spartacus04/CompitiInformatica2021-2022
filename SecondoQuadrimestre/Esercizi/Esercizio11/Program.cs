using System;

namespace Esercizio11
{
    class Program
    {
        static void Main(string[] args)
        {
            Course c = new Course("C#", 30, "Mario Rossi");

			c.addParticipant("Luigi Rossi");
			c.addParticipant("Giovanni Verdi");

			Console.WriteLine(c.getNumberOfParticipants());
			Console.WriteLine(c.getParticipats());
        }
    }
}
