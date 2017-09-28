using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class PrimeFinder
    {
        public event Action<int> FoundPrime;
        Action<String> logger = Logger.LogToConsole;

        public void FindPrimes(int maxNumber)
        {
            // find all prime numbers up until the given number
            for (int i = 1; i <= maxNumber; i++)
            {
                if (IsPrime(i))
                {
                    //Console.WriteLine(i);
                    //logger(i.ToString());
                    FoundPrime?.Invoke(i);
                }
            }
        }
        public bool IsPrime(int number)
        {
            // check if a given number is a prime
            int boundary = (int)Math.Sqrt(number);
            if (number <= 1) return false;
            if (number == 2) return true;
            // even numbers are never prime
            if (number % 2 == 0) return false;
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
