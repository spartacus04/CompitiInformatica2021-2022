using System;
using System.Collections.Generic;

namespace Esercizio8
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
			do {
				Console.WriteLine("Inserisci il numero di terreni da analizzare:");
				N = int.Parse(Console.ReadLine());
			} while (N < 1);

			Terrain[] terrains = new Terrain[N];
			loadArr(terrains);

			do {
				switch(menu()) {
					case 1:
						Terrain max = maxBuildable(terrains);
						Console.WriteLine(max.toString());

						break;
					case 2:
						double average = averageAnnuity(terrains);
						Console.WriteLine("Il rendimento medio è di " + average + "€/m2");

						break;
					case 3:
						Console.WriteLine("Inserisci l'id del terreno da cercare: ");
						string id = Console.ReadLine();

						Terrain terrain = terrainByCode(terrains, id);

						if (terrain != null) {
							Console.WriteLine("La rendita totale è di " + terrain.getTotalAnnuity() + "€");
							Console.WriteLine("La superficie edificabile è di " + terrain.buildableMeters() + "m2");
						}
						else
							Console.WriteLine("Terreno non trovato");

						break;
					case 4:
						return;
				}
			} while (true);
        }

		#region loading/menu
		static void loadArr(Terrain[] terrains) {
			for (int i = 0; i < terrains.Length; i++) {
				Console.WriteLine("Inserisci il codice del terreno:");
				string id = Console.ReadLine();

				Console.WriteLine("Inserisci l'estensione del terreno:");
				int extension = int.Parse(Console.ReadLine());

				Console.WriteLine("Inserisci il percentuale di terreno edificabile:");
				int buildablePercentage = int.Parse(Console.ReadLine());

				Console.WriteLine("Inserisci la rendita per metro quadro:");
				double annuityPerSquareMeter = double.Parse(Console.ReadLine());

				terrains[i] = new Terrain(id, extension, buildablePercentage, annuityPerSquareMeter);
			}
		}


		static int menu() {
			Console.WriteLine("\n\n1) Stampa il terreno con maggior numero di metri quadrati edificabili");
			Console.WriteLine("2) Stampa la rendita media dei terreni");
			Console.WriteLine("3) Stampa i dati di un terreno dato il suo codice");
			Console.WriteLine("4) Esci");

			int N;
			do
			{
				Console.WriteLine("Scegli un'opzione:");
				N = int.Parse(Console.ReadLine());
			} while (N < 1 || N > 4);

			return N;
		}

		#endregion

		#region options
		static Terrain maxBuildable(Terrain[] terrains) {
			Terrain max = terrains[0];

			for (int i = 1; i < terrains.Length; i++) {
				if (terrains[i].buildableMeters() > max.buildableMeters()) {
					max = terrains[i];
				}
			}

			return max;
		}

		static double averageAnnuity(Terrain[] terrains) {
			double sum = 0;

			for (int i = 0; i < terrains.Length; i++) {
				sum += terrains[i].getTotalAnnuity();
			}

			return sum / terrains.Length;
		}

		static Terrain terrainByCode(Terrain[] terrains, string code) {
			for (int i = 0; i < terrains.Length; i++) {
				if (terrains[i].Id == code) {
					return terrains[i];
				}
			}

			return null;
		}

		#endregion
	}
}
