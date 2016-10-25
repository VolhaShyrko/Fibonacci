using System.Collections.Generic;

namespace FibonacciNumber
{
    public class Fibonacci
    {
        public List<int> GetFibonacci(int number)
        {
            int first = 1;
            int second = 1;
            int sum = 0;

            List<int> result = new List<int> { 1 };

            while (number > sum)
            {
                sum = first + second;
                first = second;
                second = sum;
                result.Add(second);
            }

            return result;
        }
    }
}