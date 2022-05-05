using System;

class Shipment {
    public int Weigth { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool IsDelivered { get; set; }

    public Shipment(int weigth, string address, string city) {
        Weigth = weigth;
        Address = address;
        City = city;
        IsDelivered = false;
    }

    public virtual double price() {
        return Weigth * 3;
    }

    public bool deliver() {
        if(IsDelivered) return false;

        IsDelivered = true;
        return true;
    }

    public virtual string print() {
        return $"{Weigth}kg in {Address}, {City}";
    }
}

class AbroadShipment : Shipment {
    public string Country { get; set; }
    public double Exchange { get; set; }

    public AbroadShipment(int weigth, string address, string city, string country, double exchange) : base(weigth, address, city) {
        Country = country;
        Exchange = exchange;
    }

    public override double price() {
        return (int)(Weigth * Exchange);
    }

    public override string print() {
        return $"{Weigth}kg in {Address}, {City} ({Country})";
    }

    public int updateExchange(double exchange) {
        double tExchange = Exchange;
        Exchange = exchange;

        if(tExchange < Exchange) return 1;
        if(tExchange > Exchange) return -1;
        return 0;
    }
}