using System;

namespace AdventOfCode2020
{
    public class Passport
    {
        public int? BirthYear { get; private set; }
        public int? IssueYear { get; private set; }
        public int? ExpirationYear { get; private set; }
        public string? Height { get; private set; }
        public string? HairColor { get; private set; }
        public string? EyeColor { get; private set; }
        public string? PassportId { get; private set; }
        public string? CountryId { get; private set; }

        public bool IsValid =>
            BirthYear is not null &&
            IssueYear is not null &&
            ExpirationYear is not null &&
            Height is not null &&
            HairColor is not null &&
            EyeColor is not null &&
            PassportId is not null;

        public static Passport Parse(string text)
        {
            var passport = new Passport();

            var items = text.Split(' ', '\n');
            foreach (var item in items)
            {
                var parts = item.Split(':');
                if (parts.Length != 2)
                    throw new ArgumentException($"Invalid item format at '{item}'.");
                var key = parts[0];
                var value = parts[1];

                switch (key)
                {
                    case "byr":
                        if (passport.BirthYear is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        if (!int.TryParse(value, out var byr))
                            throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
                        passport.BirthYear = byr;
                        break;

                    case "iyr":
                        if (passport.IssueYear is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        if (!int.TryParse(value, out var iyr))
                            throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
                        passport.IssueYear = iyr;
                        break;

                    case "eyr":
                        if (passport.ExpirationYear is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        if (!int.TryParse(value, out var eyr))
                            throw new ArgumentException($"Invalid value for '{key}'.", nameof(text));
                        passport.ExpirationYear = eyr;
                        break;

                    case "hgt":
                        if (passport.Height is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        passport.Height = value;
                        break;

                    case "hcl":
                        if (passport.HairColor is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        passport.HairColor = value;
                        break;

                    case "ecl":
                        if (passport.EyeColor is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        passport.EyeColor = value;
                        break;

                    case "pid":
                        if (passport.PassportId is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        passport.PassportId = value;
                        break;

                    case "cid":
                        if (passport.CountryId is not null)
                            throw new ArgumentException($"Duplicate key '{key}'.", nameof(text));
                        passport.CountryId = value;
                        break;

                    default:
                        throw new ArgumentException($"Invalid item key '{key}'.", nameof(text));
                }
            }

            return passport;
        }
    }
}