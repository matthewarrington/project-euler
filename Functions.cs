namespace project_euler
{
    using System.Collections.Generic;

    internal static class Functions
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

        public static IEnumerable<int> Primes()
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