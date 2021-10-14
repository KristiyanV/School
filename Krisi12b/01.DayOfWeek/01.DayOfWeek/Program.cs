using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace _01.DaysOfweek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Sathurday", "Sunday" };
            int day = int.Parse(Console.ReadLine());
            if (day >= 1 && day <= 7)
            {
                Console.WriteLine(days[day - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

        }
    }
}