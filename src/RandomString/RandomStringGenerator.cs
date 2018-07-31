using System;
using System.Text;

namespace RandomString
{
    /// <summary>
    /// Generates a random string based on a character set and RNG.
    /// </summary>
    public sealed class RandomStringGenerator
    {
        private readonly IRandomNumberGenerator rng;
        private readonly ICharacterSet set;

        public RandomStringGenerator(IRandomNumberGenerator rng, ICharacterSet set)
        {
            this.rng = rng;
            this.set = set;
        }

        /// <summary>
        /// Generates a string of random characters of the specified length.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <returns></returns>
        public string GenerateString(int length)
        {
            if (length < 1)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");

            var builder = new StringBuilder(length);

            for (var i = 0; i < length; i++)
            {
                var random = rng.Next(set.Length - 1);
                var value = set.GetChar(random);

                builder.Append(value);
            }

            return builder.ToString();
        }
    }
}
