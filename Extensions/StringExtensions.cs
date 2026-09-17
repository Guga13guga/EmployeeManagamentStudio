using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentStudio.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;
        var words = str.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i][1..].ToLower();
            }
        }
        return string.Join(' ', words);
    }

    public static string ToSentenceCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;
        return char.ToUpper(str[0]) + str[1..].ToLower();
    }

}
