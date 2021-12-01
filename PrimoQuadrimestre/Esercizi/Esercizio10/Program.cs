using System;


namespace Esercizio10 {
    class Program {

        struct film {
            public string title;
            public string author;
            public float cashout;
            public string nationality;
        };

        static void Main(string[] args) {
            int N = input("Inserisci il numero di film");
            Console.WriteLine("Inserisci la tua nazionalità");
            string nationality = Console.ReadLine();

            film[] films = loadArr(N);

            do {
                switch (menu()) {
                    case 1:
                        printCashoutAverageByAuthor(films);
                        break;
                    case 2:
                        printFilmByTitle(films);
                        break;
                    case 3:
                        printHighestCashoutAbroad(films, nationality);
                        break;
                    case 4:
                        return;
                }
            } while (true);
        }

        static int input(string message) {
            int N;
            do {
                Console.WriteLine(message);
                N = int.Parse(Console.ReadLine());
            } while (N < 0);
            return N;
        }

        static float inputFloat(string message) {
            float N;
            do {
                Console.WriteLine(message);
                N = float.Parse(Console.ReadLine());
            } while (N < 0);
            return N;
        }

        static film[] loadArr(int N) {
            film[] films = new film[N];
            for (int i = 0; i < N; i++) {
                Console.WriteLine("Inserisci il titolo del film " + (i + 1));
                films[i].title = Console.ReadLine();
                Console.WriteLine("Inserisci l'autore del film " + (i + 1));
                films[i].author = Console.ReadLine();
                films[i].cashout = inputFloat("Inserisci l'incasso del film " + (i + 1));
                Console.WriteLine("Inserisci la nazionalità del film " + (i + 1));
                films[i].nationality = Console.ReadLine();
            }
            return films;
        }

        static int menu() {
            Console.WriteLine("\n\n");
            Console.WriteLine("1) Incasso medio di un autore");
            Console.WriteLine("2) Dati di un film a scelta");
            Console.WriteLine("3) Maggiore incasso di un film straniero");
            Console.WriteLine("4) Esci");
            Console.WriteLine("\n\n");

            int N = input("Scegli un opzione");

            Console.WriteLine("\n\n");
            return N;
        }

        static void printFilm(film film) {
            Console.WriteLine("Titolo\tAutore\tIncasso\tNazionalità");
            Console.WriteLine(film.title + "\t" + film.author + "\t" + film.cashout + "\t" + film.nationality);
        }

        static void printCashoutAverageByAuthor(film[] films) {
            float average = 0;
            int count = 0;
            Console.WriteLine("Inserisci il nome dell'autore");
            string name = Console.ReadLine();

            for (int i = 0; i < films.Length; i++) {
                if (films[i].author == name) {
                    count++;
                    average += films[i].cashout;
                }
            }

            average /= count;
            Console.WriteLine("L'incasso medio di " + name + " è " + average);
        }

        static void printFilmByTitle(film[] films) {
            Console.WriteLine("Inserisci il nome del film");
            string query = Console.ReadLine();

            int index = searchFilmByTitle(films, query);
            if(index == -1) {
                Console.WriteLine("Il film non è stato trovato");
                return;
            }

            printFilm(films[index]);
        }

        static int searchFilmByTitle(film[] films, string query) {
            for (int i = 0; i < films.Length; i++) {
                if (films[i].title == query) {
                    return i;
                }
            }
            return -1;
        }
        
        static void printHighestCashoutAbroad(film[] films, string nationality) {
            film HighestFilm = new film();
            HighestFilm = films[0];

            for (int i = 1; i < films.Length; i++) {
                if (films[i].nationality != nationality && films[i].cashout > HighestFilm.cashout) {
                    HighestFilm = films[i];
                }
            }

            printFilm(HighestFilm);
        }
    }
}