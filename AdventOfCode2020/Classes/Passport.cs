using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a valid passport.
    /// </summary>
    /// <remarks>Used with <see cref="Day04"/>.</remarks>
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

        /// <summary>
        /// The year that the passport holder was born. This can be between 1920
        /// and 2002.
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// The year that the passport was issued. This can be between 2010 an
        /// 2020.
        /// </summary>
        public int IssueYear { get; set; }

        /// <summary>
        /// The year that the passport will expire. this can be between 2020 and
        /// 2030.
        /// </summary>
        public int ExpirationYear { get; set; }

        /// <summary>
        /// The height of the passport holder. This can be between 150 and 193
        /// centimeters or 59 and 76 inches.
        /// </summary>
        public Height Height { get; set; }

        /// <summary>
        /// The hair color of the passport holder.
        /// </summary>
        public Color HairColor { get; set; }

        /// <summary>
        /// They eye color of the passport holder.
        /// </summary>
        public EyeColor EyeColor { get; set; }

        /// <summary>
        /// The ID of this passport. This is a 10-digit number, possibly with
        /// leading zeroes.
        /// </summary>
        public int PassportId { get; set; }

        /// <summary>
        /// The ID of the country that the passport was issued in. Note that
        /// this value is being ignored.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid birth year.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The birth year, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid birth year;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseBirthYear(string text, out int value)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            value = default;
            return Regex.IsMatch(text, @"^\d{4}$") &&
                int.TryParse(text, out value) &&
                value is >= 1920 and <= 2002;
        }

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid issue year.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The issue year, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a issue birth year;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseIssueYear(string text, out int value)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            value = default;
            return Regex.IsMatch(text, @"^\d{4}$") &&
                int.TryParse(text, out value) &&
                value is >= 2010 and <= 2020;
        }


        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid expiration
        /// year.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The expiration year, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid expiration
        /// year; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseExpirationYear(string text, out int value)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            value = default;
            return Regex.IsMatch(text, @"^\d{4}$") &&
                int.TryParse(text, out value) &&
                value is >= 2020 and <= 2030;
        }

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid height.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The height, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid height;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseHeight(string text, out Height height)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            return AdventOfCode2020.Height.TryParse(text, out height) &&
                height is
            { Value: >= 150 and <= 193, Unit: HeightUnit.Centimeter } or
            { Value: >= 59 and <= 76, Unit: HeightUnit.Inch };
        }

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid hair color.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The hair color, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid hair color;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseHairColor(string text, out Color color)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

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

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid eye color.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The eye color, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid eye color;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseEyeColor(string text, out EyeColor color)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            return EyeColors.TryGetValue(text, out color);
        }

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a valid passport ID.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="value">The passport ID, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid passport ID;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParsePassportId(string text, out int id)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            id = default;
            return Regex.IsMatch(text, @"^[0-9]{9}$") && int.TryParse(text, out id);
        }
    }
}