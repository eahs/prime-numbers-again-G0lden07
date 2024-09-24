using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
	        int count = 1;
	        int prime = 2;
	        List<int> primes = GeneratePrimesUpTo(2000000);

	        for (int i = 3; count < n; i += 2)
	        {
		        if (IsPrime(primes, i))
		        {
			        count++;
			        prime = i;
		        }
	        }

            return prime;
        }

        static List<int> GeneratePrimesUpTo(int limit)
        {
	        List<int> primeList = new List<int>();
	        bool[] isPrime = new bool[limit + 1];
	        for (int i = 2; i <= limit; i++) isPrime[i] = true;

	        for (int p = 2; p * p <= limit; p++)
	        {
		        if (isPrime[p])
		        {
			        for (int multiple = p * p; multiple <= limit; multiple += p)
			        {
				        isPrime[multiple] = false;
			        }
		        }
	        }

	        for (int i = 2; i <= limit; i++)
	        {
		        if (isPrime[i])
		        {
			        primeList.Add(i);
		        }
	        }

	        return primeList;
        }

        static bool IsPrime(List<int> primes, int n)
        {
	        double sqrt = Math.Sqrt((double)n);

            if(sqrt%1 == 0) return false;

            foreach (int prime in primes)
            {
	            if (prime > sqrt) break;
	            if (n % prime == 0) return false;
            }

	        return true;
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
