﻿using System;

namespace Memoization
{
    class Program
    {

        static long NaiveFibonacci(int n) =>
            n < 2 ? n : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);

        static void Demonstrate(Func<int, long> fibonacci)
        {
            int offSet = 30;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{offSet + i}\t{fibonacci(offSet + i)}");
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            Demonstrate(NaiveFibonacci);
            Console.ReadKey();
        }
    }
}