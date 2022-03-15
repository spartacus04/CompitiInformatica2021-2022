using System;

namespace Esercizio10
{
    class Program
    {
        static void Main(string[] args)
        {
			int N;

			do
			{
				Console.WriteLine("Inserisci il numero di prodotti");
			} while (!int.TryParse(Console.ReadLine(), out N));


			Product[] products = new Product[N];

			loadArr(products);

			int currentMonth = 0;

			do
			{
				switch(menu()) {
					case 1:
						for(int i = 0; i < products.Length; i++)
							products[i].ToString();

						break;
					case 2: {
						Console.WriteLine("Inserisci il nome del prodotto");
						int index = findByName(products, Console.ReadLine());

						if(index != -1) {
							Console.WriteLine("Inserisci il numero di pezzi da vendere");
							int quantity = int.Parse(Console.ReadLine());

							if(products[index].sell(quantity, currentMonth)) {
								Console.WriteLine("Venduto");
							} else {
								Console.WriteLine("Non ci sono abbastanza pezzi");
							}
						} else
							Console.WriteLine("Prodotto non trovato");

						break;
					}
					case 3: {
						Console.WriteLine("Inserisci il nome del prodotto");
						int index = findByName(products, Console.ReadLine());

						if(index != -1) {
							Console.WriteLine("Inserisci il numero di pezzi da vendere");
							int quantity = int.Parse(Console.ReadLine());

							products[index].buy(quantity);
						} else
							Console.WriteLine("Prodotto non trovato");

						break;
					}
					case 4: {
						Console.WriteLine("Inserisci il nome del prodotto");
						int index = findByName(products, Console.ReadLine());

						if(index != -1) {
							for(int i = 0; i < products[index].MonthlySales.Length; i++)
								Console.WriteLine("Mese " + i + " : " + products[index].MonthlySales[i]);
						} else
							Console.WriteLine("Prodotto non trovato");

						break;
					}
					case 5: {
						Console.WriteLine("Inserisci il nome del prodotto");
						int index = findByName(products, Console.ReadLine());

						if(index != -1) {
							products[index].applyDiscount();
						} else
							Console.WriteLine("Prodotto non trovato");

						break;
					}
					case 6: {
						Console.WriteLine("Inserisci il nome del prodotto");
						int index = findByName(products, Console.ReadLine());

						if(index != -1) {
							Console.WriteLine("Valore prodotti: " + products[index].value());
						} else
							Console.WriteLine("Prodotto non trovato");

						break;
					}
					case 7: {
						do
						{
							Console.WriteLine("Inserisci il mese da impostare(1-12)");
						} while (int.TryParse(Console.ReadLine(), out currentMonth));
						
						break;
					}
					case 8:
						return;


				}
			} while (true);
        }

		static int menu() {
			Console.WriteLine("\n\n1) Visualizza prodotti");
			Console.WriteLine("2) Vendi prodotto");
			Console.WriteLine("3) Acquista prodotto");
			Console.WriteLine("4) Visualizza vendite mensili di un prodotto");
			Console.WriteLine("5) Applica sconto a un prodotto");
			Console.WriteLine("6) Visualizza valore di tutti i pezzi di un prodotto");
			Console.WriteLine("7) Seleziona mese corrente");
			Console.WriteLine("8) Esci");

			int choice;
			do
			{
				Console.WriteLine("Scegli un opzione: ");
			} while (int.TryParse(Console.ReadLine(), out choice));

			Console.WriteLine("\n");

			return choice;
		}

		static void loadArr(Product[] products) {
			for (int i = 0; i < products.Length; i++)
			{
				Console.WriteLine("Inserisci il nome del prodotto " + (i + 1));
				string name = Console.ReadLine();

				Console.WriteLine("Inserisci la descrizione del prodotto " + (i + 1));
				string description = Console.ReadLine();

				double price;
				do
				{
					Console.WriteLine("Inserisci il prezzo del prodotto " + (i + 1));
				} while (!double.TryParse(Console.ReadLine(), out price));

				int quantity;
				do
				{
					Console.WriteLine("Inserisci la quantità del prodotto " + (i + 1));
				} while (!int.TryParse(Console.ReadLine(), out quantity));

				products[i] = new Product(name, description, price, quantity);				
			}
		}

		static int findByName(Product[] products, string name) {
			for (int i = 0; i < products.Length; i++)
			{
				if (products[i].Name == name)
					return i;
			}

			return -1;
		}
    }
}
