using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public bool IsValidPassport(out Passport passport)
        {
            passport = default;
            if (!IsComplete)
                return false;

            if (Passport.TryParseBirthYear(items["byr"], out int birthYear) &&
                Passport.TryParseIssueYear(items["iyr"], out int issueYear) &&
                Passport.TryParseExpirationYear(items["eyr"], out int expirationYear) &&
                Passport.TryParseHeight(items["hgt"], out Height height) &&
                Passport.TryParseHairColor(items["hcl"], out Color hairColor) &&
                Passport.TryParseEyeColor(items["ecl"], out EyeColor eyeColor) &&
                Passport.TryParsePassportId(items["pid"], out int passportId))
            {
                passport.BirthYear = birthYear;
                passport.IssueYear = issueYear;
                passport.ExpirationYear = expirationYear;
                passport.Height = height;
                passport.HairColor = hairColor;
                passport.EyeColor = eyeColor;
                passport.PassportId = passportId;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public enum EyeColor { Amber, Blue, Brown, Gray, Green, Hazel, Other }

    public struct Passport
    {
        private static readonly Dictionary<string, EyeColor> EyeColors = new()
        {
            ["amb"] = EyeColor.Amber,
            ["blu"] = EyeColor.Blue,
            ["brn"] = EyeColor.Brown,
            ["gry"] = EyeColor.Gray,
            ["grn"] = EyeColor.Green,
            ["hzl"] = EyeColor.Hazel,
            ["oth"] = EyeColor.Other,
        };

        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public Height Height { get; set; }
        public Color HairColor { get; set; }
        public EyeColor EyeColor { get; set; }
        public int PassportId { get; set; }
        public int CountryId { get; set; }

        public static bool TryParseBirthYear(string text, out int value)
        {
            value = default;
            return Regex.IsMatch(text, @"^\d{4}$") &&
                int.TryParse(text, out value) &&
                value is >= 1920 and <= 2002;
        }

        public static bool TryParseIssueYear(string text, out int value)
        {
            value = default;
            return Regex.IsMatch(text, @"^\d{4}$") &&
                int.TryParse(text, out value) &&
                value is >= 2010 and <= 2020;
        }

        public static bool TryParseExpirationYear(string text, out int value)
        {
            value = default;
            return Regex.IsMatch(text, @"^\d{4}$") &&
                int.TryParse(text, out value) &&
                value is >= 2020 and <= 2030;
        }

        public static bool TryParseHeight(string text, out Height height)
        {
            return AdventOfCode2020.Height.TryParse(text, out height) &&
                height is
            { Value: >= 150 and <= 193, Unit: HeightUnit.Centimeter } or
            { Value: >= 59 and <= 76, Unit: HeightUnit.Inch };
        }

        public static bool TryParseHairColor(string text, out Color color)
        {
            if (Regex.IsMatch(text, @"^#[0-9a-f]{6}$"))
            {
                color = ColorTranslator.FromHtml(text);
                return true;
            }
            else
            {
                color = default;
                return false;
            }
        }

        public static bool TryParseEyeColor(string text, out EyeColor color)
        {
            return EyeColors.TryGetValue(text, out color);
        }

        public static bool TryParsePassportId(string text, out int id)
        {
            id = default;
            return Regex.IsMatch(text, @"^[0-9]{9}$") && int.TryParse(text, out id);
        }
    }

    public enum HeightUnit { Centimeter, Inch }

    public struct Height
    {
        private static readonly Regex regex = new($"^(?<value>[0-9]+)(?<unit>cm|in)$");

        public int Value { get; init; }
        public HeightUnit Unit { get; init; }

        public static bool TryParse(string text, out Height height)
        {
            var match = regex.Match(text);
            if (!match.Success)
            {
                height = default;
                return false;
            }

            height = new Height
            {
                Value = int.Parse(match.Groups["value"].Value),
                Unit = match.Groups["unit"].Value switch
                {
                    "cm" => HeightUnit.Centimeter,
                    "in" => HeightUnit.Inch,
                    _ => throw new NotImplementedException()
                }
            };

            return true;
        }
    }
}