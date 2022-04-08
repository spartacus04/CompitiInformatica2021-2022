using System;

class Dispenser {
	public int Id { get; set; }
	public string Name { get; set; }
	public int Count { get; set; }
	public bool Enabled { get; set; }
	public double Price { get; set; }

	public void reload(int count) {
		if(!Enabled) {
			Console.WriteLine("Il distributore è disabilitato");
			return;
		}
		this.Count += count;
	}

	public double sell() {
		if(!Enabled) {
			Console.WriteLine("Il distributore è disabilitato");
			return;
		}
		Count--;
		return Price;
	}

	public void repair() {
		this.enabled = true;
	}

	public Dispenser(int id, string name, int count, bool enabled, double price) {
		this.Id = id;
		this.Name = name;
		this.Count = count;
		this.Enabled = enabled;
		this.Price = price;
	}
}


class cumulativeDispenser : Dispenser {
	public double sell(int count) {
		if(!Enabled) {
			Console.WriteLine("Il distributore è disabilitato");
			return;
		}
		if (this.Count < count) {
			Console.WriteLine("Non ci sono abbastanza biglietti");
			return 0;
		}
		this.Count -= count;
		return count * this.Price;
	}
}