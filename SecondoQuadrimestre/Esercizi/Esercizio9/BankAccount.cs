using System;

class BankAccount
{
	private string ownerName;
	private int id;
	private float balance;
	private string hashedPassword;
	private bool isLoggedIn;

	#region Constructors
	public BankAccount(string ownerName, float balance, string password)
	{
		this.ownerName = ownerName;
		this.balance = balance;
		this.id = new Random().Next(10000, 100000);
		this.hashedPassword = hash(password);
	}

	#endregion

	#region getters/setters
	public string OwnerName
	{
		get { 
			if(isLoggedIn) return this.ownerName; 
			return "";
			}
		set { 
			if(isLoggedIn) this.ownerName = value; 
			}
	}

	public int Id
	{
		get { return this.id; }
		private set {}
	}

	public float Balance
	{
		get { 
			if(isLoggedIn) return this.balance; 
			else return -1;
			}
		private set {}
	}

	#endregion

	#region Methods
	public void Deposit(int amount)
	{
		if(!isLoggedIn) return;
		
		balance += amount;
	}

	public bool Withdraw(int amount)
	{
		if(!isLoggedIn) return false;

		if(balance >= amount)
		{
			balance -= amount;
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool Authenticate(string password)
	{
		if(isLoggedIn) return false;

		if(hashedPassword == hash(password)) {
			isLoggedIn = true;
			return true;
		} 

		return false;
	}

	// Semplice algoritmo crittografico per la password
	private string hash(string password)
	{
		char[] chars = password.ToCharArray();

		for (int i = 0; i < chars.Length; i++)
		{
			chars[i] = (char)(chars[i] + i);
		}

		return new string(chars);
	}

	public void logOut() {
		isLoggedIn = false;
	}

	public new string ToString()
	{
		if(!isLoggedIn) return "";

		return "Correntista: " + ownerName + "\tID: " + id + "\tSaldo: " + balance;
	}
#endregion
}