using System.Text.RegularExpressions;
using ZawgyiToUnicode.ConversionRules;

namespace ZawgyiToUnicode.Converter;

public class Convert
{
    public static string? ToZawgyi(string unicodeText) => DoConversion(unicodeText, Rules.UnicodeToZawgyiRules);
    public static string? ToUnicode(string zawgyiText) => DoConversion(zawgyiText, Rules.ZawgyiToUnicodeRules);

    private static string DoConversion(string input, IReadOnlyDictionary<string, string> conversionRules)
    {
        foreach (var rule in conversionRules)
        {
            Regex rgx = new(rule.Key);
            input = rgx.Replace(input, rule.Value);
        }

        return input;
    }
}
