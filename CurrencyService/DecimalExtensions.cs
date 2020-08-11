using System;

public static class DecimalExtensions
    {
        public static int WholeNumberPart(this decimal number) {
            return (int)Math.Truncate(number);
        }

        public static int ReminderDigits(this decimal number)
        {
            var decimalPart = number - Math.Truncate(number);
            if (decimalPart == 0) {
                return 0;
            }
            return int.Parse(decimalPart.ToString().Substring(2, 2));
        }
    }