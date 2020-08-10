using System;

namespace CurrencyService
{
    public class CurrencyService
    {
        public string ConvertToText(decimal currency) {
            var text = string.Empty;

            var wholeNumberPart = (int)Math.Truncate(currency);

            if (currency < 20 && CurrencyLookup.NumberTexts.ContainsKey(wholeNumberPart)) {
                text = CurrencyLookup.NumberTexts[wholeNumberPart];
            }

            var isDivisibleBy10 = currency % 10 == 0;
            if (isDivisibleBy10 && CurrencyLookup.TenMultipleTexts.ContainsKey(wholeNumberPart)) {
                text = CurrencyLookup.TenMultipleTexts[wholeNumberPart];
            }

            return text;
        }
    }
}
