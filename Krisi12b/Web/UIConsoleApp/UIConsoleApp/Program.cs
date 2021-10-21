using Data;
using System;

namespace UIConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductContext db = new ProductContext();
            db.Database.EnsureCreated();
            Display display = new Display();
        }
    }
}
