namespace project_euler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static partial class Problem
    {
        //--------------------------------------------------
        // https://projecteuler.net/problem=1
        //
        // If we list all the natural numbers below 10 that are multiples of 3 or 5,
        // we get 3, 5, 6 and 9. The sum of these multiples is 23.
        // Find the sum of all the multiples of 3 or 5 below 1000.
        //--------------------------------------------------
        public static (int, string) P0001()
        {
            var result = 0;
            for(var i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            return (1, result.ToString());
        }

        //--------------------------------------------------
        // https://projecteuler.net/problem=2
        //
        // Each new term in the Fibonacci sequence is generated by adding the previous
        // two terms. By starting with 1 and 2, the first 10 terms will be:
        //
        //      1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        //
        // By considering the terms in the Fibonacci sequence whose values do not exceed
        // four million, find the sum of the even-valued terms.
        //--------------------------------------------------
        // Notes:
        // I guess this would classically be a recursive function, but I want to write
        // a sequence generator.       
        //--------------------------------------------------
        public static (int, string) P0002()
        {
            var result = FibSequence(1, 2, 4000000)
                .Where(x => x % 2 == 0)
                .Sum(x => x)
                .ToString();

            return (2, result);
        }

        private static IEnumerable<int> FibSequence(int a, int b, int max)
        {
            yield return a;
            yield return b;

            (a, b) = (b, a + b);
            while (b < max)
            {
                yield return b;
                (a, b) = (b, a + b);
            }
        }

        //--------------------------------------------------
        // https://projecteuler.net/problem=3
        //
        // The prime factors of 13195 are 5, 7, 13 and 29.
        //
        // What is the largest prime factor of the number 600851475143?
        //--------------------------------------------------
        // Notes:
        // Current plan:
        //  1. Find next prime (as before, use a generator because fun and
        //     convenient)
        //  2. Test if target is divisible by prime, reducing target by
        //     all occurrences
        //  3. Repeat, stop when target is equal to the current prime?
        //     (Stop when target == 1, simpler loop logic)
        //--------------------------------------------------
        public static (int, string) P0003()
        {
            var target = 600851475143;

            foreach(var p in Primes().Take(1000))
            {
                while (target % p == 0)
                {
                    target /= p;
                }
                if (target == 1)
                {
                    return (3, p.ToString());
                }
            }

            throw new Exception("Ran out of primes without resolution.");
        }

        private static IEnumerable<int> Primes()
        {
            var primes = new List<int>() { 2 };
            var i = 3;

            yield return 2;

            while(true)
            {
                var isPrime = true;
                foreach(var p in primes)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        continue;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                    yield return i;
                }

                i += 2;
            }
        }
    }
}