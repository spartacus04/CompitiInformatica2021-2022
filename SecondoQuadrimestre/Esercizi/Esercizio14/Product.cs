using System;

class Product {
    public string Name { get; set; }
    public string Desc { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Id { get; set; }

    public int[] Sold { get; set; } = new int[12];

    public Product(string name, string desc, double price, int quantity, string id) {
        Name = name;
        Desc = desc;
        Price = price;
        Quantity = quantity;
        Id = id;
    }

    public virtual void ApplyDiscount() {
        Price *= 0.95;
    }

    public bool Sell(int quantity, int month) {
        if (Quantity >= quantity) {
            Sold[month] += quantity;
            Quantity -= quantity;
            return true;
        }

        return false;
    }

    public void Buy(int quantity) {
        Quantity += quantity;
    }

    public double GetPrice() {
        return Price * Quantity;
    }

    public virtual string toString() {
        return $"{Name} - {Desc} - {Price} - {Quantity} - {Id}";
    }
}

class FoodProduct : Product {
    public DateTime ExpirationDate { get; set; }

    public FoodProduct(string name, string desc, double price, int quantity, string id, DateTime expirationDate) : base(name, desc, price, quantity, id) {
        ExpirationDate = expirationDate;
    }

    public override void ApplyDiscount() {
        if(ExpirationDate < DateTime.Now.AddDays(10)) {
            Price *= 0.8;
        }
    }

    public override string toString() {
        return $"{Name} - {Desc} - {Price} - {Quantity} - {Id} - {ExpirationDate.ToShortDateString()}";
    }
}

class NonFoodProduct : Product {
    public bool Recyclable { get; set; }

    public NonFoodProduct(string name, string desc, double price, int quantity, string id, bool recyclable) : base(name, desc, price, quantity, id) {
        Recyclable = recyclable;
    }

    public override void ApplyDiscount() {
        if(Recyclable) {
            Price *= 0.9;
        }
    }

    public override string toString() {
        return $"{Name} - {Desc} - {Price} - {Quantity} - {Id} - {Recyclable}";
    }
}