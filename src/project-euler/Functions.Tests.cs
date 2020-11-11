using System;
using System.Linq;
using Xunit;

namespace project_euler
{
    public class FunctionsTests
    {
        [Theory]
        [InlineData(10, 0, 1, "0,1,1,2,3,5,8,13,21,34")]
        [InlineData(10, 1, 2, "1,2,3,5,8,13,21,34,55,89")]
        [InlineData(10, 1, 5, "1,5,6,11,17,28,45,73,118,191")]
        public void Fibonacci_PositiveInputs_ReturnsPositiveSequence(int numTerms, int valA, int valB, string expected)
        {
            var actualVals = Functions.Fibonacci(valA, valB).Take(numTerms);
            var actual = string.Join(',', actualVals.Select(x => x.ToString()));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 0, -1, "0,-1,-1,-2,-3,-5,-8,-13,-21,-34")]
        [InlineData(10, -1, -2, "-1,-2,-3,-5,-8,-13,-21,-34,-55,-89")]
        [InlineData(10, -1, -5, "-1,-5,-6,-11,-17,-28,-45,-73,-118,-191")]
        public void Fibonacci_NegativeInputs_ReturnsNegativeSequence(int numTerms, int valA, int valB, string expected)
        {
            var actualVals = Functions.Fibonacci(valA, valB).Take(numTerms);
            var actual = string.Join(',', actualVals.Select(x => x.ToString()));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(25, 0, 0, "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0")]
        public void Fibonacci_Zeroes_ReturnsZeroes(int numTerms, int valA, int valB, string expected)
        {
            var actualVals = Functions.Fibonacci(valA, valB).Take(numTerms);
            var actual = string.Join(',', actualVals.Select(x => x.ToString()));
            Assert.Equal(expected, actual);
        }

        [Theory]
        // Expected values pulled from Le Internet
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(10, 29)]
        [InlineData(100, 541)]
        [InlineData(1000, 7919)]
        [InlineData(10000, 104729)]
        [InlineData(100000, 1299709)]
        public void Primes_GenerateNPrimes_ReturnsNthPrime(int nthPrime, int expected)
        {
            var actual = Functions.Primes().Skip(nthPrime - 1).First();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(43)]
        [InlineData(197)]
        [InlineData(2207)]
        [InlineData(44497)]
        [InlineData(524287)]
        public void Factor_PrimeNumbers_ReturnsInput(int input)
        {
            var actual = Functions.Factor(input);
            Assert.Single(actual.Keys);
            Assert.True(actual?.ContainsKey(input));
            Assert.Equal(1, actual[input]);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(23, 32)]
        [InlineData(456, 654)]
        public void ReverseInt_PositiveIntegers_ReturnsReversedInput(int input, int expected)
        {
            var actual = Functions.ReverseInt(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5, -5)]
        [InlineData(-23, -32)]
        [InlineData(-456, -654)]
        public void ReverseInt_NegativeIntegers_ReturnsReversedInput(int input, int expected)
        {
            var actual = Functions.ReverseInt(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(50, 5)]
        [InlineData(7700, 77)]
        [InlineData(303000300, 3000303)]
        public void ReverseInt_InputEndingInZero_ReturnsShorterInput(int input, int expected)
        {
            var actual = Functions.ReverseInt(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 100, "99,88,77,66,55,44,33,22,11")]
        [InlineData(4, 11, "9999,9889,9779,9669,9559,9449,9339,9229,9119,9009,8998")]
        [InlineData(8, 4, "99999999,99988999,99977999,99966999")]
        public void GeneratePalindromicIntegers_ValidInput_ReturnsValues(int input, int numTerms, string expected)
        {
            var actualVals = Functions.GeneratePalindromicIntegers(input).Take(numTerms);
            var actual = string.Join(',', actualVals.Select(x => x.ToString()));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(10)]
        public void GeneratePalindromicIntegers_InvalidInput_TriggersWarnings(int input)
        {
            Assert.Throws<Exception>(() =>
                Functions.GeneratePalindromicIntegers(input).Take(1).ToList()
                );
        }
    }
}
