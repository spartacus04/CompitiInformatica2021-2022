using System;

namespace verifica
{
    class Program
    {
		struct Song {
			public string name;
			public string author;
			public int duration;

			public int[] singularGrades;
			public int grade;
		}
        static void Main(string[] args)
        {
			int n;
			do
			{
				Console.WriteLine("Inserisci il numero di brani: ");
				n = int.Parse(Console.ReadLine());
			} while (n < 1);

			Song[] songs = new Song[n];

			loadArr(songs);

			do
			{
				switch(menu()) {
					case 1:
						int lastIndex = last(songs);
						Console.WriteLine("Nome\tAutore\tDurata\tVoto");
						printSong(songs[lastIndex]);

						break;
					case 2:
						int _averageDuration = averageDuration(songs);
						Console.WriteLine("Durata media dei brani (in secondi): " + _averageDuration);

						break;
					case 3:
						int pos;
						do
						{
							Console.WriteLine("Inserisci il numero del brano: ");
							pos = int.Parse(Console.ReadLine()) - 1;
						} while (pos < 0 || pos > n);

						int _maxGrade = maxGrade(songs[pos]);
						Console.WriteLine("Voto massimo del brano: " + songs[pos].singularGrades[_maxGrade]);

						break;
					case 4:
						Console.WriteLine("Nome\tVoto Massimo");
						for (int i = 0; i < songs.Length; i++)
						{
							int grade = maxGrade(songs[i]);
							Console.WriteLine(songs[i].name + "\t" + songs[i].singularGrades[grade]);
						}

						break;
					case 5:
						Console.WriteLine("Inserisci il titolo della canzone: ");
						int index = findByTitle(songs, Console.ReadLine());

						if (index != -1)
							reinsertGrades(ref songs[index]);
						else
							Console.WriteLine("Nessun brano trovato");

						break;
					case 6:
						sortByDuration(songs);

						Console.WriteLine("Nuovo ordine: \nNome\tDurata");
						for(int i = 0; i < songs.Length; i++)
							Console.WriteLine(songs[i].name + "\t" + songs[i].duration);
						
						break;
					case 7:
						int judgeIndex = maxJudgeVote(songs);
						Console.WriteLine("Il giudice numero " + (judgeIndex + 1) + " ha votato i voti più alti");

						break;
					case 8:
						return;
				}
			} while (true);
        }


		static void loadArr(Song[] songs) {
			for (int i = 0; i < songs.Length; i++)
			{
				Console.WriteLine("Inserisci il nome del brano " + (i + 1) + ": ");
				songs[i].name = Console.ReadLine();

				Console.WriteLine("Inserisci l'autore del brano " + (i + 1) + ": ");
				songs[i].author = Console.ReadLine();

				do
				{
					Console.WriteLine("Inserisci la durata del brano "  + (i + 1) + " (min: 100, max: 210): ");
					songs[i].duration = int.Parse(Console.ReadLine());
				} while (songs[i].duration < 100 || songs[i].duration > 210);

				songs[i].singularGrades = new int[10];
				for (int j = 0; j < 10; j++)
				{
					int temp = 0;
					do
					{
						Console.WriteLine("Inserisci la valutazione del brano "  + (i + 1) + " assegnata dal giudice numero " + (j + 1) + " (min: 0, max: 10): ");
						temp = int.Parse(Console.ReadLine());
					} while (temp < 0 || temp > 10);

					songs[i].singularGrades[j] = temp;
					songs[i].grade += temp;
				}
				
			}
		}
    
		static int menu() {
			Console.WriteLine("\n\n1) Visualizzare il brano ultimo classificato");
			Console.WriteLine("2) Visualizzare la durata media dei brani");
			Console.WriteLine("3) Visualizzare il voto massimo ricevuto di un brano");
			Console.WriteLine("4) Visualizzare tutti i brani con un voto massimo ricevuto");
			Console.WriteLine("5) Reinserire i punteggi di un brano");
			Console.WriteLine("6) Ordinare il vettore per la dimensione della durata");
			Console.WriteLine("7) Determinare il giudice che ha dato un punteggio piu alto");
			Console.WriteLine("8) Esci");

			int n;
			do
			{
				Console.WriteLine("\nScegli un opzione: ");
				n = int.Parse(Console.ReadLine());
			} while (n < 1 || n > 8);

			Console.WriteLine("\n");
			return n;
		}
	
		static int last(Song[] songs) {
			int max = 100;
			int index = 0;
			for(int i = 0; i < songs.Length; i++) {
				if(songs[i].grade < max) {
					max = songs[i].grade;
					index = i;
				}
			}

			return index;
		}

		static void printSong(Song song) {
			Console.WriteLine(song.name + "\t" + song.author + "\t" + song.duration + "\t" + song.grade);
		}
	
		static int averageDuration(Song[] songs) {
			int average = 0;
			for (int i = 0; i < songs.Length; i++)
			{
				average += songs[i].duration;
			}

			return average / songs.Length;
		}

		static int maxGrade(Song song) {
			int min = 0;
			int index = -1;
			for(int i = 0; i < song.singularGrades.Length; i++) {
				if(song.singularGrades[i] > min) {
					min = song.singularGrades[i];
					index = i;
				}
			}

			return index;
		}

		static int findByTitle(Song[] songs, string title) {
			for (int i = 0; i < songs.Length; i++)
			{
				if (songs[i].name == title)
					return i;
			}

			return -1;
		}

		static void reinsertGrades(ref Song song) {
			for (int i = 0; i < song.singularGrades.Length; i++)
			{
				int temp = 0;
				do
				{
					Console.WriteLine("Inserisci la valutazione del brano assegnata dal giudice numero " + (i + 1) + " (min: 0, max: 10): ");
					temp = int.Parse(Console.ReadLine());
				} while (temp < 0 || temp > 10);

				song.singularGrades[i] = temp;
				song.grade += temp;
			}
		}
	
		static void sortByDuration(Song[] songs) {
			// Bubble sort
			for (int i = 0; i < songs.Length; i++)
			{
				for (int j = i; j < songs.Length - 1; j++)
				{
					if (songs[j].duration > songs[j + 1].duration)
					{
						Song temp = songs[j];
						songs[j] = songs[j + 1];
						songs[j + 1] = temp;
					}
				}
			}
		}
	
		static int maxJudgeVote(Song[] songs) {
			int[] grades = new int[10];
			for (int i = 0; i < songs.Length; i++)
			{
				for (int j = 0; j < songs[i].singularGrades.Length; j++)
				{
					grades[j] += songs[i].singularGrades[j];
				}
			}

			int min = grades[0];
			int index = 0;

			for(int i = 0; i < grades.Length; i++) {
				if(grades[i] > min) {
					min = grades[i];
					index = i;
				}
			}

			return index;
		}
	}
}
