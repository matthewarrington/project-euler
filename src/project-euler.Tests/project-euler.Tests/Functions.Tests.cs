using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace project_euler.Tests
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
        // Expected values pulled from Le Internet
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(10, 29)]
        [InlineData(100, 541)]
        [InlineData(1000, 7919)]
        [InlineData(10000, 104729)]
        [InlineData(100000, 1299709)]
        public void Primes_GenerateNPrimes_ReturnsNthPrime2(int nthPrime, int expected)
        {
            var sut = new PrimeNumberGenerator();

            var actual = sut.Primes().Skip(nthPrime - 1).First();
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
        [InlineData(5, new int[] { 5 })]
        [InlineData(23, new int[] { 2, 3 })]
        [InlineData(123456, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void ToDigits_PositiveInteger_ReturnsDigits(int input, int[] expected)
        {
            var actual = Functions.ToDigits(input).ToArray();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, new int[] { 5 })]
        [InlineData(23, new int[] { 2, 3 })]
        [InlineData(1234567890123456789L, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ToDigits_PositiveBigInteger_ReturnsDigits(long input, int[] expected)
        {
            var i = new BigInteger(input);
            var actual = Functions.ToDigits(i).ToArray();
            Assert.Equal(expected, actual);
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

        [Fact]
        public void TriangleNumber_FirstTen_ReturnsSequence()
        {
            var expected = new List<int>() { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 };
            var actual = Enumerable.Range(1, 10).Select(x => Functions.TriangleNumber(x)).ToList();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 15)]
        [InlineData(10, 55)]
        [InlineData(35, 630)]
        [InlineData(85, 3655)]
        [InlineData(100, 5050)]
        public void TriangleNumber_GenerateNNumbers_ProducesNthNumber(int nthNumber, int expected)
        {
            var actual = Functions.TriangleNumber(nthNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(15, 5)]
        [InlineData(55, 10)]
        [InlineData(630, 35)]
        [InlineData(3655, 85)]
        [InlineData(5050, 100)]
        public void TriangleTermNumber_TriangleNumber_ReturnsTermNumber(int number, int expected)
        {
            var actual = Functions.TriangleTermNumber(number);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(14)]
        [InlineData(56)]
        [InlineData(631)]
        [InlineData(3658)]
        [InlineData(5043)]
        public void TriangleNumber_NotATriangleNumber_ReturnsZero(int number)
        {
            var expected = 0;
            var actual = Functions.TriangleTermNumber(number);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        [InlineData(55)]
        [InlineData(630)]
        [InlineData(3655)]
        [InlineData(5050)]
        public void IsTriangleNumber_TriangleNumber_ReturnsTrue(int number)
        {
            var actual = Functions.IsTriangleNumber(number);
            Assert.True(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(14)]
        [InlineData(56)]
        [InlineData(631)]
        [InlineData(3658)]
        [InlineData(5043)]
        public void IsTriangleNumber_NotATriangleNumber_ReturnsFalse(int number)
        {
            var actual = Functions.IsTriangleNumber(number);
            Assert.False(actual);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 1, 1)]
        [InlineData(0, 123, 456, 789, 0, 999)]
        [InlineData(-100, 5, -2, 1, 5, 2)]
        public void Product_InputFiveValues_ReturnsProduct(long expected, long val1, long val2, long val3, long val4, long val5)
        {
            var actual = new[] { val1, val2, val3, val4, val5 }.Product();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(32, 1, 1, 1, 1, 1)]
        [InlineData(4724200, 12, 45, 78, 0, 99)]
        [InlineData(-216, 5, -2, 1, 5, 2)]
        public void Product_InputFiveValuesPlus1_ReturnsProduct(long expected, long val1, long val2, long val3, long val4, long val5)
        {
            var actual = new[] { val1, val2, val3, val4, val5 }.Product(x => x + 1);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5L, 120L)]
        [InlineData(4L, 24L)]
        [InlineData(3L, 6L)]
        [InlineData(2L, 2L)]
        public void Factorial_PositiveInteger_ReturnsPositiveFactorial(long n, long expected)
        {
            var actual = Functions.Factorial(n);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Factorial_Zero_ThrowsInvalidArgument()
        {
            Assert.Throws<ArgumentException>(() => { Functions.Factorial(0); });
        }
    }
}
