using System;
using System.Collections.Generic;
using System.Linq;

namespace project_euler
{
    /// <summary>
    /// This class generates prime numbers. The first run is slightly slower
    /// than Functions.Primes(), but being able to reuse the primes list is
    /// a pretty big win.
    /// </summary>
    public class PrimeNumberGenerator
    {
        public IEnumerable<long> Primes()
        {
            foreach (var p in _primes.ToList())
            {
                yield return p;
            }

            while (true)
            {
                yield return GenerateNextPrime();
            }
        }

        private long GenerateNextPrime()
        {
            var possibleNextPrime = _primes[_primes.Count - 1] + 2;
            var primesLen = _primes.Count;

            while (true)
            {
                var stopValue = Math.Sqrt(possibleNextPrime);
                for (int i = 0; i < primesLen; i++)
                {
                    var knownPrime = _primes[i];
                    if (knownPrime > stopValue)
                    {
                        _primes.Add(possibleNextPrime);
                        return possibleNextPrime;
                    }
                    else if (possibleNextPrime % knownPrime == 0)
                    {
                        possibleNextPrime += 2;
                        break;
                    }
                }
            }
        }

        private List<long> _primes = new List<long>() { 2L, 3L, 5L, 7L };
    }
}
