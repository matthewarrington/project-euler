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
            var result = Functions.Fibonacci(1, 2)
                .TakeWhile(x => x <= 4000000)
                .Where(x => x % 2 == 0)
                .Sum(x => x)
                .ToString();

            return (2, result);
        }

        //--------------------------------------------------
        // https://projecteuler.net/problem=3
        //
        // The prime factors of 13195 are 5, 7, 13 and 29.
        //
        // What is the largest prime factor of the number 600851475143?
        //--------------------------------------------------
        // Plan:
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

            foreach(var p in Functions.Primes().Take(1000))
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

        //--------------------------------------------------
        // https://projecteuler.net/problem=4
        //
        // A palindromic number reads the same both ways. The largest palindrome
        // made from the product of two 2-digit numbers is 9009 = 91 × 99.
        //
        // Find the largest palindrome made from the product of two 3-digit
        // numbers.
        //--------------------------------------------------
        // Plan:
        //  * I don't know enough about mathematics to casually know the
        //    numeric patterns that would lead to this. I'm going to try
        //    making it a search problem.
        //  * "PNum" = Palindromic Number
        //  1. Fabricate pnums, starting with the largest possible (999999)
        //     a. Create it from a three digit number, repeated
        //     b. Start with 999, decrement as that fails, etc
        //  2. Make guesses for two numbers
        //     a. Start with the sqrt of the pnum, truncated
        //     b. Take the product of this A * B and compare it to the pnum
        //        * If the product is too small, increment A
        //        * If the product is too large, decrement B
        //     c. Stop when:
        //        * Victory: The product == pnum
        //        * Defeat: A or B is no longer 3 digits
        //  3. Try different pnums until we're out of 6-digit numbers
        //--------------------------------------------------
        public static (int, string) P0004()
        {
            foreach(var pNum in GeneratePalindromes())
            {
                var a = (int)Math.Sqrt(pNum);
                var b = a;

                while (a <= 999 && b >= 100)
                {
                    var product = a * b;

                    if (product == pNum)
                    {
                        return (4, product.ToString());
                    }
                    else if (product < pNum)
                    {
                        a++;
                    }
                    else
                    {
                        b--;
                    }
                }
            }

            throw new Exception("Ran out of palindromes without resolution.");
        }

        private static IEnumerable<int> GeneratePalindromes()
        {
            var seed = 999;

            while (seed >= 100)
            {
                yield return seed * 1000 + Functions.ReverseInt(seed);
                seed--;
            }
        }

        //--------------------------------------------------
        // https://projecteuler.net/problem=5
        //
        // 2520 is the smallest number that can be divided by each of the numbers
        // from 1 to 10 without any remainder.
        //
        // What is the smallest positive number that is evenly divisible by all
        // of the numbers from 1 to 20?
        //--------------------------------------------------
        // Plan:
        //  * Find the set of factors for each input. Make a new set of factors,
        //    composed of the highest count of each factor among the set. Result
        //    is the product of the new set of factors.
        //    TODO: Come up with a better explanation. Factor factor factor.
        //--------------------------------------------------
        public static (int, string) P0005()
        {
            // "factors" is x[factor] = counts;
            var factors = new Dictionary<int, int>();
            for(int i = 20; i > 1; i--)
            {
                factors.MergeFactors(Functions.Factor(i));
            }

            var result = factors.Keys
                .Aggregate(1, (product, factor) => product * (int)Math.Pow(factor, factors[factor])
                );

            return (5, result.ToString());
        }

        private static void MergeFactors(this Dictionary<int, int> factors, Dictionary<int, int> newFactors)
        {
            foreach(var nk in newFactors.Keys)
            {
                if (!factors.ContainsKey(nk) || factors[nk] < newFactors[nk])
                {
                    factors[nk] = newFactors[nk];
                }
            }
        }

        //--------------------------------------------------
        // https://projecteuler.net/problem=6
        //
        // The sum of the squares of the first ten natural numbers is,
        //
        //          1^2 + 2^2 + ... + 10^2 = 385
        //
        // The square of the sum of the first ten natural numbers is,
        //
        //          (1 + 2 + ... + 10)^2 = 55^2 = 3025
        //
        // Hence the difference between the sum of the squares of the first ten natural
        // numbers and the square of the sum is
        //
        //          3025 - 385 = 2640
        //
        // Find the difference between the sum of the squares of the first one hundred
        // natural numbers and the square of the sum.
        //--------------------------------------------------
        // Plan:
        //  * Brute force
        //--------------------------------------------------
        public static (int, string) P0006()
        {
            var max = 100;
            var sumOfSquares = Enumerable.Range(1, max).Select(x => (int)Math.Pow(x, 2)).Sum();
            var squareOfSums = (int)Math.Pow(Enumerable.Range(1, max).Sum(), 2);

            return (6, (squareOfSums - sumOfSquares).ToString());
        }
    }
}