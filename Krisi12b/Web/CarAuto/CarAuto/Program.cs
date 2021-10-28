using Data;
using System;

namespace CarAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            CarsContext db = new CarsContext();
            db.Database.EnsureCreated();
            Display display = new Display();
        }
    }
}
