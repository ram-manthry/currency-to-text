using System.Collections.Generic;

public class CurrencyLookup {
    public static Dictionary<int, string> NumberTexts = new Dictionary<int, string>() {
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
        };

    public static Dictionary<int, string> TenDivisibleTexts = new Dictionary<int, string>() {
        {0, "Zero"},
        {10, "Ten"},
        {20, "Twenty"},
        {30, "Thirty"},
        {40, "Forty"},
        {50, "Fifty"},
        {60, "Sixty"},
        {70, "Seventy"},
        {80, "Eighty"},
        {90, "Ninety"},
        {100, "Hundred"},
        {1000, "Thousand"},
    };
}