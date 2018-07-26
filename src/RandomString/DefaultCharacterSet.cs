using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    /// <summary>
    /// Represents a set of characters used to generate a random string.
    /// </summary>
    public class DefaultCharacterSet : ICharacterSet
    {
        public const string Characters = "0123456789ABCDFGHJKLMNPQRSTVWXYZ";
        private const int _length = 32;

        static DefaultCharacterSet()
        {
            // Sanity check to ensure our lengths match
            if (Characters.Length != _length)
                throw new ArgumentException("Invalid Character Length.");
        }

        /// <summary>
        /// Returns the total number of characters in this set.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// Returns the character located at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char GetChar(int index)
        {
            if (index < 0 || index >= Characters.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");

            return Characters[index];
        }
    }
}
