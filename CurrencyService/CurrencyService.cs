using System;

namespace CurrencyService
{
    public class CurrencyService
    {
        public string TranslateToEnglish(decimal amount) {
            var text = string.Empty;
            var dollars = TranslateToEnglish(amount.WholeNumberPart(), "dollars");
            var reminderDigits = amount.ReminderDigits();
            var cents = reminderDigits > 0 ? " " + TranslateToEnglish(reminderDigits, "cents") : string.Empty;
            return dollars + cents;
        }

        private string Conjuctor(string text, string filler) => string.IsNullOrEmpty(text) ? string.Empty : filler;

        private string TranslateToEnglish(int amount, string currency) {
            var text = string.Empty;

            if (amount == 0) {
                return "zero " + currency;
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
                    text = Lookup.NumberTexts[(currentNumber - previousNumber) / 100] + " hundred" + Conjuctor(text, " and ") + text;
                }
                
                previousNumber = currentNumber;
            } while(moduloDivider <= amount);

            return text + " " + currency;
        }
    }
}
