using NUnit.Framework;
using FluentAssertions;

namespace CurrencyService.Tests
{
    public class DecimalExtensionsTests
    {

        [TestCase(0.21, 0)]
        [TestCase(1.35,1)]
        [TestCase(99.22, 99)]
        public void WholeNumberPartTest(decimal input, int expected)
        {
            var actual = input.WholeNumberPart();
            actual.Should().Be(expected);
        }

        [TestCase(0.21, 21)]
        [TestCase(1.35,35)]
        [TestCase(22.99, 99)]
        [TestCase(123.456, 45)]
        [TestCase(789.1234, 12)]
        [TestCase(0,0)]
        public void FractionalPartTest(decimal input, int expected)
        {
            var actual = input.FractionalPart();
            actual.Should().Be(expected);
        }
    }
}