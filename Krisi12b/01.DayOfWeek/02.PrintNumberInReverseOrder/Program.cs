using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PrintNumberInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            { 
                arr[i] = int.Parse(Console.ReadLine()); 
            }
            Array.Reverse(arr);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
