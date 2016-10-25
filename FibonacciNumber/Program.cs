using System;
using System.Collections.Generic;

namespace FibonacciNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ICacheManager manager = new CacheManager();
            ICacheManager manager = new RedisCacheManager();
            Process(manager);
        }

        public static void Process(ICacheManager manager)
        {
            Console.WriteLine("Enter the last figure for Fibonacci row");
            Console.WriteLine("If you want to exit please enter stop");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                int number = Convert.ToInt32(input);

                List<int> numbers = manager.Get(input);
                if (numbers != null)
                {
                    Console.WriteLine("From cache.");
                }
                else
                {
                    Fibonacci f = new Fibonacci();
                    numbers = f.GetFibonacci(number);

                    manager.Set(input, numbers);
                }

                Console.WriteLine(string.Join(" ", numbers));
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}