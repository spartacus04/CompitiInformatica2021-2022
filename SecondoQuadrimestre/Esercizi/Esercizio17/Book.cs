using System;

class Book {
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public double Price { get; set; }
    public bool IsLent { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, string publisher, double price) {
        Title = title;
        Author = author;
        Publisher = publisher;
        Price = price;
        IsLent = false;
        IsAvailable = true;
    }

    public void Lend() {
        if(IsLent || !IsAvailable) return;
        IsLent = true;
        IsAvailable = false;
    }

    public void Return() {
        if(!IsLent || IsAvailable) return;
        IsLent = false;
        IsAvailable = true;
    }

    public virtual string Print() {
        return $"{Title} di {Author}, pubblicato da {Publisher}, {Price} euro, {(IsLent ? "in prestito" : "non in prestito")}, {(IsAvailable ? "disponibile" : "non disponibile")}";
    }
}

class AncientBook : Book {
    public int Year { get; set; }
    public int ConservationSttatus { get; set; }

    public AncientBook(string title, string author, string publisher, double price, int year, int conservationStatus) : base(title, author, publisher, price) {
        Year = year;
        ConservationSttatus = conservationStatus;
    }

    public override string Print() {
        return $"{Title} di {Author}, pubblicato da {Publisher}, {Price} euro, {(IsLent ? "in prestito" : "non in prestito")}, {(IsAvailable ? "disponibile" : "non disponibile")}, {Year}, {ConservationSttatus}";
    }

    public void UpdateConservation(int i) {
        ConservationSttatus = i;
    }
}