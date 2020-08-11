using System;

namespace CurrencyService
{
    public class CurrencyService
    {
        public string TranslateToEnglish(decimal amount) {
            return TranslateToEnglish(amount.WholeNumberPart(), "Dollars");
        }

        private string Conjuctor(string text, string filler) => string.IsNullOrEmpty(text) ? string.Empty : filler;

        private string TranslateToEnglish(int amount, string currency) {
            var text = string.Empty;

            if (amount == 0) {
                return "Zero " + currency;
            }

            var moduloDivider = 1;
            var currentNumber = 0;
            var previousNumber = 0;

            do {
                moduloDivider *= 10;
                currentNumber = amount % moduloDivider;

                if (currentNumber == 0) {
                    continue;
                }

                if (currentNumber <= 20) {
                    text = Lookup.NumberTexts[currentNumber];
                } else if (currentNumber < 100) {
                    text = Lookup.NumberTexts[currentNumber - previousNumber] + Conjuctor(text, " ") + text;
                } else if (currentNumber < 1000) {
                    text = Lookup.NumberTexts[(currentNumber - previousNumber) / 100] + " Hundred" + Conjuctor(text, " And ") + text;
                }
                
                previousNumber = currentNumber;
            } while(moduloDivider <= amount);

            return text + " " + currency;
        }
    }
}
