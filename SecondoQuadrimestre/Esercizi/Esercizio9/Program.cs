using System;

namespace Esercizio9
{
    class Program
    {
        static void Main(string[] args)
        {
			int N;
			do
			{
            	Console.WriteLine("Inserisci il numero di conti da creare: ");
				N = int.Parse(Console.ReadLine());
			} while (N < 0);

			BankAccount[] accounts = new BankAccount[N];

			loadArr(accounts);

			do
			{
				login(accounts);
				Console.WriteLine("\n\n\n");
			} while (true);
        }


		static void login(BankAccount[] accounts) {
			Console.WriteLine("Inserisci il numero di conto: ");
			int id = int.Parse(Console.ReadLine());
			int index = findById(accounts, id);

			if(index == -1) {
				Console.WriteLine("Non ho trovato quel conto corrente");
			}

			Console.WriteLine("Inserisci la password: ");
			string password = Console.ReadLine();
			
			if(accounts[index].Authenticate(password)) {
				Console.WriteLine("Autenticato con successo");
				do
				{
					Console.WriteLine("\n\n\n");
					switch(menu()) {
						case 1:
							Console.WriteLine("Inserisci l'importo da depositare: ");
							int amount = int.Parse(Console.ReadLine());

							accounts[index].Deposit(amount);

							break;
						case 2:
							Console.WriteLine("Inserisci l'importo da prelevare: ");
							amount = int.Parse(Console.ReadLine());

							if(accounts[index].Withdraw(amount)) {
								Console.WriteLine("Prelievo effettuato con successo");
							} else {
								Console.WriteLine("Non hai abbastanza soldi");
							}

							break;
						case 3:
							Console.WriteLine("Il tuo saldo è: " + accounts[index].Balance);

							break;
						case 4:
							Console.WriteLine("Inserisci il nuovo nome del correntista");
							
							accounts[index].OwnerName = Console.ReadLine();

							break;
						case 5:
							accounts[index].logOut();
							Console.WriteLine("Arrivederci\n\n\n");

							return;
					}
				} while (true);
			}
			else {
				Console.WriteLine("Password errata");
			}
		}

		static int findById(BankAccount[] accounts, int id)
		{
			for (int i = 0; i < accounts.Length; i++)
			{
				if (accounts[i].Id == id)
				{
					return i;
				}
			}
			return -1;
		}

		static void loadArr(BankAccount[] accounts) {
			for (int i = 0; i < accounts.Length; i++) {
				Console.WriteLine("Inserisci il nome del conto: ");
				string name = Console.ReadLine();

				int bal;
				do
				{
					Console.WriteLine("Inserisci il saldo del conto: ");
					bal = int.Parse(Console.ReadLine());
				} while (bal < 0);

				Console.WriteLine("Inserisci la password del conto: ");
				string pass = Console.ReadLine();

				accounts[i] = new BankAccount(name, bal, pass);

				Console.WriteLine("L'ID del conto è " + accounts[i].Id);
			}
		}

		static int menu() {
			Console.WriteLine("1. Deposita denaro");
			Console.WriteLine("2. Preleva denaro");
			Console.WriteLine("3. Stampa saldo");
			Console.WriteLine("4. Cambia nome correntista");
			Console.WriteLine("5. Esci");

			int n;
			do
			{
				Console.WriteLine("Scegli un opzione: ");
				n = int.Parse(Console.ReadLine());
			} while (n < 1 || n > 5);

			Console.WriteLine("\n\n\n");

			return n;
		}
    }
}
