using System;

namespace Esercizio6
{
    class Program
    {
        static void Main(string[] args)
        {
			int N;
			do
			{
				Console.WriteLine("Inserisci il numero di squadre");
				N = int.Parse(Console.ReadLine());
			} while (N < 0);

			Team[] teams = new Team[N];

			loadArr(teams);

			Console.WriteLine("\n\n\n");

			do
			{
				int index = findByName(teams);
				if(index == -1) continue;

				switch(menu())
				{
					case 1:
						Console.WriteLine("La squadra " + teams[index].getName() + " ha " + teams[index].getPoints() + " punti");
 						break;
					case 2:
						teams[index].reset();
						Console.WriteLine("Ho resettato il numero di partite della squadra " + teams[index].getName());
						break;
					case 3:
						int res;
						do
						{
							Console.WriteLine("Inserisci il risultato della partita (0-pareggio, 1-vittoria, 2-sconfitta)");
							res = int.Parse(Console.ReadLine());
						} while (res < 0 || res > 2);

						teams[index].addGameResult(res);
						Console.WriteLine("Ho aggiunto il risultato della partita alla squadra " + teams[index].getName());
						break;
					case 4:
						int type;
						do
						{
							Console.WriteLine("Inserisci il tipo di statistica da visualizzare (0-vittorie, 1-sconfitte, 2-pareggi)");
							type = int.Parse(Console.ReadLine());
						} while (type < 0 || type > 2);

						Console.WriteLine("La squadra " + teams[index].getName() + " ha " + teams[index].getGameResult(type) + " " + (type == 0 ? "vittorie" : type == 1 ? "sconfitte" : "pareggi"));
						break;
					case 5:
						Console.WriteLine(teams[index].output());
						break;
					case 6:
						return;
				}
			} while (true);
        }

		static void loadArr(Team[] teams) {
			for (int i = 0; i < teams.Length; i++) {
				Console.WriteLine("Inserisci il nome della squadra " + (i + 1));
				string name = Console.ReadLine();
				Console.WriteLine("Inserisci il numero di partite vinte della squadra " + (i + 1));
				int wonGames = int.Parse(Console.ReadLine());
				Console.WriteLine("Inserisci il numero di partite perse della squadra " + (i + 1));
				int lostGames = int.Parse(Console.ReadLine());
				Console.WriteLine("Inserisci il numero di partite pareggiate della squadra " + (i + 1));
				int tiedGames = int.Parse(Console.ReadLine());
				teams[i] = new Team(name, wonGames, lostGames, tiedGames);
			}
		}
    
		static int menu() {
			Console.WriteLine("\n\n\n");
			Console.WriteLine("1) Numero di punti di una squadra");
			Console.WriteLine("2) Reimposta una squadra");
			Console.WriteLine("3) Aggiunge risultato di una partita");
			Console.WriteLine("4) Numero di partite vinte/perse/pareggiate di una squadra");
			Console.WriteLine("5) Stampa le informazioni della squadra");
			Console.WriteLine("6) Esci");
			Console.WriteLine("\n\n\n");

			int N;
			do
			{
				Console.WriteLine("Inserisci il numero dell'operazione da eseguire");
				N = int.Parse(Console.ReadLine());
			} while (N < 1 || N > 6);

			Console.WriteLine("\n\n\n");
			return N;
		}

		static int findByName(Team[] teams) {
			string n;
			do
			{
				Console.WriteLine("Inserisci il nome della squadra con cui si vuole interagire");
				n = Console.ReadLine();
			} while (n == "");

			for (int i = 0; i < teams.Length; i++) {
				if (teams[i].getName() == n) {
					return i;
				}
			}
			
			Console.WriteLine("Squadra non trovata");
			return -1;
		}
	}
}