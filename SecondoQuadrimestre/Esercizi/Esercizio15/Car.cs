using System;

class Car {
    public string LicensePlate { get; set; }
    public int Displacement { get; set; } // Non ho idea di come si dica cilindrata in inglese
    public string Brand { get; set; }
    public Person Owner { get; set; }

    public Car(string licensePlate, int displacement, string brand, Person owner) {
        LicensePlate = licensePlate;
        Displacement = displacement;
        Brand = brand;
        Owner = owner;
    }

    public override string ToString()
    {
        return $"{LicensePlate} {Displacement} {Brand}\n{Owner}";
    }
}