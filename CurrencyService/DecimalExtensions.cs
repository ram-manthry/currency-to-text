using System;

public static class DecimalExtensions
    {
        public static int WholeNumberPart(this decimal number) {
            return (int)Math.Truncate(number);
        }

        public static int FractionalPart(this decimal number)
        {
            var fractionalPart = number - Math.Truncate(number);
            if (fractionalPart == 0) {
                return 0;
            }
            return int.Parse(fractionalPart.ToString().Substring(2, 2));
        }
    }