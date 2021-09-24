using System;
using System.Collections.Generic;

namespace Esercizio3 {
    class Program {
        static void Main(string[] args) {
            const int max = 100;
            int n = input("Inserisci il numero di numeri da caricare nel vettore");

            while (n <= max) {
                Console.WriteLine("Il numero deve essere più piccolo di 100");
                n = input("Inserisci il numero di numeri da caricare nel vettore");
            }

            //Vettore con pari e dispari
            //Sorting pari o dispari

            string oddOrEven;
            do {
                Console.WriteLine("Vuoi visualizzare la somma dei numeri pari o dispari? (P/D)");
                oddOrEven = Console.ReadLine().ToLower();
            } while (oddOrEven == "p" || oddOrEven == "d");

            bool allowEven = oddOrEven == "p" ? true : false;

            int[] arr = new int[n];
            bool isEven = true;
            int sumEven = 0;
            int sumOdd = 0;

            //Calcolo somma indici pari e dispari

            for (int i = 0; i < n; i++) {
                int num = input("Inserisci il valore all'indice " + i);
                arr[i] = num;

                if (isEven && allowEven) {
                    sumEven += num;
                } else if (!isEven && !allowEven) {
                    sumOdd += num;
                }
                isEven = !isEven;
            }

            if (allowEven) {
                Console.WriteLine("La sommma dei numeri pari è " + sumOddOrEven(arr, 0));
                Console.WriteLine("La somma dei numeri agli indici pari è " + sumEven);
            } else {
                Console.WriteLine("La sommma dei numeri dispari è " + sumOddOrEven(arr, 1));
                Console.WriteLine("La somma dei numeri agli indici dispari è " + sumOdd);
            }

            //Ricerca numeri pari e dispari

            int[] sortedArr = new int[n];
            int count = 0;

            int[] evenArr = filterArr(arr, 0);
            Console.WriteLine("I numeri pari sono: ");

            for (int i = 0; i < evenArr.Length; i++) {
                sortedArr[count] = evenArr[i];
                count++;
                Console.WriteLine(evenArr[i]);
            }
            int[] oddArr = filterArr(arr, 1);
            Console.WriteLine("I numeri dispari sono: ");

            for (int i = 0; i < oddArr.Length; i++) {
                sortedArr[count] = oddArr[i];
                count++;

                Console.WriteLine(oddArr[i]);
            }

            Console.WriteLine("I numeri ordinati sono");

            for (int i = 0; i < sortedArr.Length; i++) {
                Console.WriteLine(sortedArr);
            }

            //Ricerca elemento nell'array
            int toFind = input("Inserisci un numero da cercare nell'array");


            int index = findElement(arr, toFind);
            if (index == -1) {
                Console.WriteLine("Elemento non trovato");
            } else {
                Console.WriteLine("L'elemento " + toFind + " è stato trovato alla posizione " + index);
            }

            //Caricare array randominco
            int[] rand = new int[n];
            for (int i = 0; i < n; i++) {
                rand[i] = new Random().Next(-200, 201);
            }
        }

        static int[] filterArr(int[] arr, int isEven) {
            //Uso lista per limitare l'array
            List<int> list = new List <int>();
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] % 2 == isEven)
                    list.Add(arr[i]);
            }
            return list.ToArray();
        }

        static int sumOddOrEven(int[] arr, int isEven) {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] % 2 == isEven)
                    sum += i;
            }
            return sum;
        }

        static int findElement(int[] arr, int element) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == element) {
                    return i;
                }
            }
            return -1;
        }

        static int input(string message, int min = 0) {
            int n;
            do {
                Console.WriteLine(message);
                n = int.Parse(Console.ReadLine());
            } while (n <= min);
            return n;
        }
    }
}