using System;
using System.Collections.Generic;

namespace CurrencyService
{
    public class CurrencyService
    {
        public string ConvertToText(int number) {
            var text = string.Empty;
            text = CurrencyLookup.NumberTexts[number];
            return text;
        }
    }
}
