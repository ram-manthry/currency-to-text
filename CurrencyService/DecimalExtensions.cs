using System;

public static class DecimalExtensions
    {
        public static int WholeNumberPart(this decimal number) {
            return (int)Math.Truncate(number);
        }

        public static int ReminderDigits(this decimal number, int count)
        {
            return int.Parse((number - Math.Truncate(number)).ToString().Substring(2, count));
        }
    }