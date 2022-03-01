using System;

namespace Esercizio7
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Andrea", new int[] {7, 8, 9, 10});

			student.editLastGrade(9);
			student.addGrade(10);
			Console.WriteLine("La media dello studente è " + Math.Round(student.getAverage(), 2));
        }
    }
}
