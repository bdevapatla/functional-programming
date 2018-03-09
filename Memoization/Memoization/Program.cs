using System;
using System.Collections.Generic;


// Memoization is a special kind of dynamic programming 
//Conversely 
//

namespace Memoization
{
    class Program
    {

        static long NaiveFibonacci(int n) =>
            n < 2 ? n : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);

        static IList<long> dynamicCache = new List<long> { 0, 1 };

        static long DynamicFibonacci(int n)
        {
            while (dynamicCache.Count <= n)
            {
                dynamicCache.Add(-1);//-1 is special marker 
            }

            if (dynamicCache[n] < 0)
            {
                dynamicCache[n] = n < 2 ? n : DynamicFibonacci(n - 1) + DynamicFibonacci(n - 2);
            }

            return dynamicCache[n];
        }

        static IList<long> forwardCache = new List<long> { 0, 1 };


        //This is not still the best dynamic programming can offer 
        static long ForwardFibonacci(int n)
        {
            while (forwardCache.Count <= n)
            {
                forwardCache.Add(forwardCache[forwardCache.Count - 1] + forwardCache[forwardCache.Count - 2]);
            }
            return forwardCache[n];
        }

        //Does not take additional space but will not use memoization for subsequent runs 
        static long QuickFibonacci(int n)
        {
            long a = 0;
            long b = 1;

            for (int i = 2; i <= n; i++)
            {
                long c = a + b;
                a = b;
                b = c;
            }
            return b;
        }

        //Proper memoization technique with MAP 

        static IDictionary<int, long> dynamicDictCache = new Dictionary<int, long>();

        static long dynamciDictFibonaaci(int n)
        {
            if (!dynamicDictCache.TryGetValue(n, out long value))
            {
                value = n < 2 ? n : dynamciDictFibonaaci(n - 2) + dynamciDictFibonaaci(n - 1);
                dynamicDictCache[n] = value;
            }
            return value;
        }

        static void Demonstrate(Func<int, long> fibonacci)
        {
            int offSet = 30; //Non-trivial calculations
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{offSet + i}\t{fibonacci(offSet + i)}");
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            Demonstrate(NaiveFibonacci);
            Demonstrate(DynamicFibonacci);
            Demonstrate(ForwardFibonacci);
            Demonstrate(QuickFibonacci);
            Console.ReadKey();
        }
    }
}
