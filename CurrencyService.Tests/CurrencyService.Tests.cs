using NUnit.Framework;
using FluentAssertions;

namespace CurrencyService.Tests
{
    public class CurrencyServiceTests
    {
        private CurrencyService _currencyService;
        [SetUp]
        public void Setup()
        {
            _currencyService = new CurrencyService();
        }

        [TestCase(0, "Zero")]
        [TestCase(1, "One")]
        [TestCase(9, "Nine")]
        public void When_Single_Digit_Then_Return_From_Dictionary(int input, string expected)
        {
            var actual = _currencyService.ConvertToText(input);
            actual.Should().Be(expected);
        }

        [TestCase(11, "Eleven")]
        [TestCase(19, "Nineteen")]
        public void When_Two_Digits_Below_20_Then_Return_From_Dictionary(int input, string expected) {
            var actual = _currencyService.ConvertToText(input);
            actual.Should().Be(expected);
        }

        [TestCase(10, "Ten")]
        [TestCase(20, "Twenty")]
        [TestCase(50, "Fifty")]
        [TestCase(90, "Ninety")]
        [TestCase(100, "One Hundred")]
        public void When_10_Multiple_Then_Lookup_From_Dictionary(int input, string expected) {
            var actual = _currencyService.ConvertToText(input);
            actual.Should().Be(expected);
        }

        [TestCase(21, "Twenty One")]
        public void When_Two_Digits_Above_20_And_Not_10_Multiple(int input, string expected) {
            var actual = _currencyService.ConvertToText(input);
            actual.Should().Be(expected);
        }
    }
}