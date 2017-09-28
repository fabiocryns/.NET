using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFinder finder = new PrimeFinder();
            finder.FoundPrime += OnFoundPrime;
            finder.FindPrimes(60);
            Console.ReadLine();
        }

        private static void OnFoundPrime(int prime)
        {
            Console.WriteLine(prime);
        }
    }
}
