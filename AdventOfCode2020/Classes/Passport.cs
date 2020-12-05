using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class PassportData
    {
        public static IEnumerable<string> RequiredKeys => new[] {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            //"cid",
        };

        private readonly Dictionary<string, string> items = new();

        public bool IsComplete => RequiredKeys.All(items.ContainsKey);

        public static PassportData Parse(string text)
        {
            var data = new PassportData();

            var items = text.Split(' ', '\n');

            foreach (var item in items)
            {
                var parts = item.Split(':');
                if (parts.Length != 2)
                    throw new ArgumentException($"Invalid item format at '{item}'.");
                var key = parts[0];
                var value = parts[1];
                if (!data.items.TryAdd(key, value))
                    throw new ArgumentException($"Duplicate key '{key}'.");
            }

            return data;
        }
    }

    public class Passport
    {
        // public static readonly Dictionary<string, EyeColor> EyeColors = new()
        // {
        //     ["amb"] = AdventOfCode2020.EyeColor.Amber,
        //     ["brn"] = AdventOfCode2020.EyeColor.Brown,
        //     ["hzl"] = AdventOfCode2020.EyeColor.Hazel,
        // };

        // public int BirthYear { get; private set; }
        // public int IssueYear { get; private set; }
        // public int ExpirationYear { get; private set; }
        // public int Height { get; private set; }
        // public Color HairColor { get; private set; }
        // public EyeColor? EyeColor { get; private set; }
        // public int? PassportId { get; private set; }
        // public int? CountryId { get; private set; }

        // public static Passport Parse(string text)
        // {
        //     var passport = new Passport();

        //     var items = text.Split(' ', '\n');
        //     foreach (var item in items)
        //     {
        //         var parts = item.Split(':');
        //         if (parts.Length != 2)
        //             throw new ArgumentException($"Invalid item format at '{item}'.");
        //         var key = parts[0];
        //         var value = parts[1];

        //         switch (key)
        //         {
        //             case "byr":
        //                 if (passport.BirthYear is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!int.TryParse(value, out var byr))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.BirthYear = byr;
        //                 break;

        //             case "iyr":
        //                 if (passport.IssueYear is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!int.TryParse(value, out var iyr))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.IssueYear = iyr;
        //                 break;

        //             case "eyr":
        //                 if (passport.ExpirationYear is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!int.TryParse(value, out var eyr))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.ExpirationYear = eyr;
        //                 break;

        //             case "hgt":
        //                 if (passport.Height is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!int.TryParse(value, out var hgt))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.Height = hgt;
        //                 break;

        //             case "hcl":
        //                 if (passport.HairColor is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 Color hcl;
        //                 try
        //                 {
        //                     hcl = ColorTranslator.FromHtml(value);
        //                 }
        //                 catch (ArgumentException e)
        //                 {
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text), e);
        //                 }
        //                 passport.HairColor = hcl;
        //                 break;

        //             case "ecl":
        //                 if (passport.EyeColor is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!EyeColors.TryGetValue(value, out var ecl))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.EyeColor = ecl;
        //                 break;

        //             case "pid":
        //                 if (passport.PassportId is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!int.TryParse(value, out var pid))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.PassportId = pid;
        //                 break;

        //             case "cid":
        //                 if (passport.CountryId is not null)
        //                     throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
        //                 if (!int.TryParse(value, out var cid))
        //                     throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
        //                 passport.CountryId = cid;
        //                 break;

        //             default:
        //                 throw new ArgumentException($"Invalid item key '{key}'.", nameof(text));
        //         }
        //     }

        //     return passport;
        // }
    }
}