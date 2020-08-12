using System;

namespace CurrencyService
{
    public class CurrencyService
    {
        private string Conjuctor(string text, string filler) => string.IsNullOrEmpty(text) ? string.Empty : filler;

        public string TranslateToEnglish(decimal amount) {
            if (amount < 0 || amount >= 1000) {
                throw new ArgumentOutOfRangeException("amount", $"Amount should be between 0 and 1000 : {amount}");
            }

            var text = string.Empty;

            var wholeNumberPart = amount.WholeNumberPart();
            var fractionalPart = amount.FractionalPart();

            if (wholeNumberPart > 0 || fractionalPart == 0) {
                text = TranslateToEnglish(wholeNumberPart, "dollars");
            }
        
            if (fractionalPart > 0) {
                text += Conjuctor(text, " and ") + TranslateToEnglish(fractionalPart, "cents");
            }
            
            return text;
        }

        private string TranslateToEnglish(int amount, string currency) {
            var text = string.Empty;

            if (amount == 0) {
                return $"{Lookup.ZERO} " + currency;
            }

            var moduloDivider = 1;
            var currentNumber = 0;
            var previousNumber = 0;

            var chain = LinkFactory.GetLink();

            do {
                moduloDivider *= 10;
                currentNumber = amount % moduloDivider;

                if (currentNumber == 0) {
                    continue;
                }

                text = chain.Execute(currentNumber, previousNumber, text);
                previousNumber = currentNumber;
                
            } while(moduloDivider <= amount);

            return text + " " + currency;
        }
    }
}
