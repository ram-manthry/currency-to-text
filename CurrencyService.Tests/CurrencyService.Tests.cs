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

        [TestCase(0, "Zero Dollars")]
        [TestCase(1, "One Dollars")]
        [TestCase(9, "Nine Dollars")]
        public void When_Single_Digit_Then_Return_From_Dictionary(decimal input, string expected)
        {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(11, "Eleven Dollars")]
        [TestCase(19, "Nineteen Dollars")]
        public void When_Two_Digits_Below_20_Then_Return_From_Dictionary(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(10, "Ten Dollars")]
        [TestCase(20, "Twenty Dollars")]
        [TestCase(50, "Fifty Dollars")]
        [TestCase(90, "Ninety Dollars")]
        [TestCase(100, "One Hundred Dollars")]
        public void When_10_Multiple_Then_Return_From_Dictionary(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(21, "Twenty One Dollars")]
        [TestCase(99, "Ninety Nine Dollars")]
        public void When_Two_Digits_Above_20_And_Not_10_Multiple_Then_Show_Two_Words(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }

        [TestCase(101, "One Hundred And One Dollars")]
        [TestCase(111, "One Hundred And Eleven Dollars")]
        [TestCase(999, "Nine Hundred And Ninety Nine Dollars")]
        public void When_Three_Digits_Then_Show_And(decimal input, string expected) {
            var actual = _currencyService.TranslateToEnglish(input);
            actual.Should().Be(expected);
        }
    }
}