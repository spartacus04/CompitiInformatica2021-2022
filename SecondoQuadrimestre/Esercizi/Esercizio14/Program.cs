using System;

namespace Esercizio14
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("prodotto1", "descrizione1", 10, 10, "id1");
            Product p2 = new FoodProduct("prodotto2", "descrizione2", 20, 20, "id2", DateTime.Now.AddDays(10));
            Product p3 = new NonFoodProduct("prodotto3", "descrizione3", 30, 30, "id3", true);
        }
    }
}
