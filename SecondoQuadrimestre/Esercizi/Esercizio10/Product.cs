using System;

class Product {
	private string name;
	private string description;
	private double price;
	private int quantity;

	private int[] monthlySales;

	#region Constructors

	public Product(string name, string description, double price, int quantity) {
		this.name = name;
		this.description = description;
		this.price = price;
		this.quantity = quantity;
		monthlySales = new int[12];
	}

	#endregion

	#region Getters/Setters

	public string Name {
		get { return name; }
		set { name = value; }
	}

	public string Description {
		get { return description; }
		set { description = value; }
	}

	public double Price {
		get { return price; }
		set { price = value; }
	}

	public int Quantity {
		get { return quantity; }
		set { quantity = value; }
	}

	public int[] MonthlySales {
		get { return monthlySales; }
		set { monthlySales = value; }
	}

	#endregion

	#region Methods

	public void applyDiscount() {
		price *= 0.95;
	}

	public bool sell(int quantity, int month) {
		if(quantity > this.quantity) {
			return false;
		}

		monthlySales[month] += quantity;
		this.quantity -= quantity;
		return true;
	}

	public void buy(int quantity) {
		this.quantity += quantity;
	}

	public double value() {
		return price * quantity;
	}

	public override string ToString() {
		return name + ": " + description + " - " + price + " - " + quantity;
	}
	
	#endregion
}