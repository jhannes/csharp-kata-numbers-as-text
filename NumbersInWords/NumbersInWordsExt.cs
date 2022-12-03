﻿namespace NumbersInWords;
public static class NumbersInWordsExt
{
    private static Dictionary<long, string> numbers = new Dictionary<long, string>() {
        { 1, "en" },
        { 2, "to" },
        { 3, "tre" },
        { 4, "fire" },
        { 5, "fem" },
        { 6, "seks" },
        { 7, "syv" },
        { 8, "åtte" },
        { 9, "ni" },
        { 10, "ti" },
        { 11, "elleve" },
        { 12, "tolv" },
        { 13, "tretten" },
        { 14, "fjorten" },
        { 15, "femten" },
        { 16, "seksten" },
        { 17, "sytten" },
        { 18, "atten" },
        { 19, "nitten" },
        { 20, "tjue" },
        { 30, "tretti" },
        { 40, "førti" },
        { 50, "femti" },
        { 60, "seksti" },
        { 70, "sytti" },
        { 80, "åtti" },
        { 90, "nitti" },
        { 100, "et hundre" },
        { 1000, "et tusen" },
        { 1_000_000, "en million" },
        { 1_000_000_000, "en milliard" },
    };

    public static string ToWords(this long n)
    {
        if (numbers.ContainsKey(n)) return numbers[n];
        if (n >= 1_000_000_000) return SplitLargeNumber(n, 1_000_000_000, "milliarder");
        if (n >= 1_000_000) return SplitLargeNumber(n, 1_000_000, "millioner");
        if (n >= 1000) return SplitLargeNumber(n, 1000, "tusen");
        if (n >= 100) return SplitLargeNumber(n, 100, "hundre");
        if (n >= 20) return numbers[(n - n % 10)] + numbers[(n % 10)];

        throw new Exception("Don't know what to do with " + n);
    }

    private static string SplitLargeNumber(long n, long value, string name)
    {
        var remainder = n % value;
        if (remainder == 0) return (n/value).ToWords() + " " + name;
        return (n - remainder).ToWords()
            + (remainder < 100 ? " og " : " ")
            + remainder.ToWords();
    }
}
