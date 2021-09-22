using System;

namespace Esercizio4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] grades = new int[10];
            for (int i = 0; i < 10; i++)
            {
                grades[i] = input("Inserisci il voto numero " + (i + 1));
            }

            double averageGrade = average(grades);
            Console.WriteLine("La media dei voti è " + Math.Round(averageGrade, 3));
            Console.WriteLine("Il voto più basso è " + minGrade(grades));
            Console.WriteLine("Il voto più alto è " + maxGrade(grades));
            Console.WriteLine("I voti insufficienti sono " + underSixGrades(grades));
            Console.ReadKey();
        }

        static int minGrade(int[] arr){
            int min = 0;
            for (int i = 0; i < 10; i++)
            {
                arr[i] = input("Inserisci il voto numero " + (i + 1));
                if(arr[i] < min){
                    min = arr[i];
                }
            }
            return min;
        }
        static int maxGrade(int[] arr){
            int max = 10;
            for (int i = 0; i < 10; i++)
            {
                arr[i] = input("Inserisci il voto numero " + (i + 1));
                if(arr[i] > max){
                    max = arr[i];
                }
            }
            return max;
        }

        static int underSixGrades(int[] arr){
            int n = 0;
            for (int i = 0; i < 10; i++)
            {
                if(arr[i] < 6)
                    n++;
            }
            return n;
        }

        static double average(int[] arr){
            int n = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                n += arr[i];
            }
            return (double)n / (double)arr.Length;
        }

        static int input(string message){
            int n;
            do
            {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > 10);
            return n;
        }
    }
}
