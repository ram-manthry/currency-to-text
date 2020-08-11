using System;

namespace CurrencyService
{
    public class CurrencyService
    {
        public string ConvertToText(decimal currency) {
            var text = string.Empty;

            var wholeNumberPart = (int)Math.Truncate(currency);

            if (wholeNumberPart == 0) {
                return "Zero";
            }

            var moduloDivider = 1;
            var currentNumber = 0;
            var previousNumber = 0;

            do {
                moduloDivider *= 10;
                currentNumber = wholeNumberPart % moduloDivider;

                if (currentNumber == 0) {
                    continue;
                }

                if (wholeNumberPart < 20) {
                    text = Lookup.NumberTexts[wholeNumberPart];
                } else if (currentNumber < 100) {
                    text = Lookup.NumberTexts[currentNumber - previousNumber] + (string.IsNullOrEmpty(text) ? string.Empty : " ") + text;
                } else if (currentNumber < 1000) {
                    text = Lookup.NumberTexts[(currentNumber - previousNumber) / 100] + " Hundred" + (string.IsNullOrEmpty(text) ? string.Empty : " And ") + text;
                }

                // var isDivisibleBy10 = wholeNumberPart % 10 == 0;
                // if (isDivisibleBy10 && Lookup.TenMultipleTexts.ContainsKey(wholeNumberPart)) {
                //     text = Lookup.TenMultipleTexts[wholeNumberPart];t
                // }
                
                previousNumber = currentNumber;
            } while(moduloDivider <= currency);

            return text;
        }
    }
}
