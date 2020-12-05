using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a set of key/value pairs from a passport document.
    /// </summary>
    /// <remarks>Used with <see cref="Day04"/>.</remarks>
    public class PassportData
    {
        /// <summary>
        /// A set of keys required for the passport to be considered complete.
        /// Note that official passports require the 'cid' key.
        /// </summary>
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

        /// <summary>
        /// True if the passport data contains all of the required keys.
        /// </summary>
        public bool IsComplete => RequiredKeys.All(items.ContainsKey);

        /// <summary>
        /// Creates an instance of <see cref="PassportData"/> from a string.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>The <see cref="PassportData"/> based on the string.</returns>
        public static PassportData Parse(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            var data = new PassportData();

            var items = text.Split(' ', '\n');

            foreach (var item in items)
            {
                var parts = item.Split(':');
                if (parts.Length != 2)
                    throw new FormatException($"Invalid item format at '{item}'.");
                var key = parts[0];
                var value = parts[1];
                if (!data.items.TryAdd(key, value))
                    throw new FormatException($"Duplicate key '{key}'.");
            }

            return data;
        }

        /// <summary>
        /// Returns true if the passport data can represent a valid passport. A
        /// passport is valid if it is complete, and if all of the required
        /// fields are in the correct format. If it is valid,
        /// <paramref name="passport"/> will contain a <see cref="Passport"/>
        /// object represented by this <see cref="PassportData"/>.
        /// </summary>
        /// <param name="passport">
        /// Will contain a <see cref="Passport"/> object represented by this
        /// <see cref="PassportData"/> if this method returns <c>true</c>.
        /// </param>
        /// <returns>True if the passport data can represent a valid passport.</returns>
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
}