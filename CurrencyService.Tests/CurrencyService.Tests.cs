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

        [TestCase(0, "zero dollars")]
        [TestCase(1, "one dollars")]
        [TestCase(9, "nine dollars")]
        public void When_Single_Digit_Then_Return_From_Dictionary(decimal input, string expected)
        {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(11, "eleven dollars")]
        [TestCase(19, "nineteen dollars")]
        public void When_Two_Digits_Below_20_Then_Return_From_Dictionary(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(10, "ten dollars")]
        [TestCase(20, "twenty dollars")]
        [TestCase(50, "fifty dollars")]
        [TestCase(90, "ninety dollars")]
        [TestCase(100, "one hundred dollars")]
        public void When_10_Multiple_Then_Return_From_Dictionary(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(21, "twenty one dollars")]
        [TestCase(99, "ninety nine dollars")]
        public void When_Two_Digits_Above_20_And_Not_10_Multiple_Then_Show_Two_Words(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(101, "one hundred and one dollars")]
        [TestCase(111, "one hundred and eleven dollars")]
        [TestCase(999, "nine hundred and ninety nine dollars")]
        public void When_Three_Digits_Then_Show_And(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(101.123, "one hundred and one dollars and twelve cents")]
        [TestCase(123.45, "one hundred and twenty three dollars fourty and five cents")]
        [TestCase(0.12, "twelve cents")]
        [TestCase(10.55, "ten dollars and fifty five cents")]
        [TestCase(120, "one hundred and twenty dollars")]
        public void When_Decimal_Places_Then_Return_Dollars_And_Cents(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }
    }
}