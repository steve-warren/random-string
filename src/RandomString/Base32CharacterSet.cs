using System;
using System.Collections.Generic;
using System.Text;

namespace RandomString
{
    /// <summary>
    /// Represents a set of characters used to generate a random string.
    /// </summary>
    public class Base32CharacterSet : ICharacterSet
    {
        public const string Characters = "0123456789ABCDFGHJKLMNPQRSTVWXYZ";

        /// <summary>
        /// Returns the total number of characters in this set.
        /// </summary>
        public int Length => Characters.Length;

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
