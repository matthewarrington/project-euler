using System;
using System.Collections.Generic;
using System.Linq;

namespace project_euler
{
    public static class Functions
    {
        public static IEnumerable<int> Fibonacci(int a, int b)
        {
            yield return a;

            while (true)
            {
                yield return b;
                (a, b) = (b, a + b);
            }
        }

        // The version I wrote of this in JS runs in a fraction of the time
        // in Chrome. Replacing "yield return" with a real collection makes
        // up the difference. It generates primes under 2m in 0.8s, which
        // seems fast enough for now.
        // Chrome version does more work (possiblePrime++ instead of += 2),
        // which leaves me pretty impressed with Chrome!
        public static IEnumerable<int> Primes()
        {
            yield return 2;

            var primes = new List<int>() { 2 };
            var possiblePrime = 3;

            while (true)
            {
                var isPrime = true;
                var stopValue = Math.Sqrt(possiblePrime);
                var primesLen = primes.Count;
                for (int i = 0; i < primesLen; i++)
                {
                    var knownPrime = primes[i];
                    if (knownPrime > stopValue)
                    {
                        break;
                    }
                    else if (possiblePrime % knownPrime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(possiblePrime);
                    yield return possiblePrime;
                }

                possiblePrime += 2;
            }
        }

        // Returns: Keys = prime factor, Value = count of occurrences
        public static Dictionary<int, int> Factor(int i)
        {
            var result = new Dictionary<int, int>();
            foreach (var p in Functions.Primes().TakeWhile(x => x <= i))
            {
                if (i % p == 0)
                {
                    result[p] = 0;
                    var i2 = i;
                    while (i2 % p == 0)
                    {
                        result[p]++;
                        i2 /= p;
                    }
                }
            }
            return result;
        }

        public static int ReverseInt(int i)
        {
            if (i < 0)
            {
                return -1 * ReverseInt(-1 * i);
            }

            var result = 0;
            while (i > 0)
            {
                result = result * 10 + i % 10;
                i /= 10;
            }
            return result;
        }

        public static IEnumerable<int> GeneratePalindromicIntegers(int numDigits)
        {
            Assure(numDigits % 2 == 0, "numDigits must be even");
            Assure(numDigits >= 2, "numDigits must be between 2 and 8");
            Assure(numDigits <= 8, "numDigits must be between 2 and 8");

            var seed = ((int)Math.Pow(10, numDigits / 2)) - 1;
            var term = ((int)Math.Pow(10, numDigits / 2 - 1));
            var mult = ((int)Math.Pow(10, numDigits / 2));

            while (seed >= term)
            {
                yield return seed * mult + Functions.ReverseInt(seed);
                seed--;
            }
        }

        // Naming this "Assure" since "Assert" is already heavily used by xUnit
        private static void Assure(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }
    }
}