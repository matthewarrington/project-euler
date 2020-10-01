namespace project_euler
{
    using System.Collections.Generic;
    using System.Linq;

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
            var i = 0;
            foreach(var i2 in _primes)
            {
                yield return i2;
                i = i2;
            }

            while(true)
            {
                var isPrime = true;
                foreach(var p in _primes)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        continue;
                    }
                }

                if (isPrime)
                {
                    _primes.Add(i);
                    yield return i;
                }

                i += 2;
            }
        }

        private static List<int> _primes = new List<int>() {2, 3};

        public static Dictionary<int, int> Factor(int i)
        {
            var result = new Dictionary<int, int>();
            foreach(var p in Functions.Primes().TakeWhile(x => x <= i))
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
            var result = 0;
            while(i > 0)
            {
                result = result * 10 + i % 10;
                i /= 10;
            }
            return result;
        }
    }
}