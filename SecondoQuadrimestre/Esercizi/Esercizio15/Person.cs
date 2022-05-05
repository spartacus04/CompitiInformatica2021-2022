using System;

class Person {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string Code { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(string name, string surname, string city, string code, DateTime birthDate) {
        Name = name;
        Surname = surname;
        City = city;
        Code = code;
        BirthDate = birthDate;
    }

    public override string ToString()
    {
        return $"{Name} {Surname} {City} {Code} {BirthDate.ToShortDateString()}";
    }
}