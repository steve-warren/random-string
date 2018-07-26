using RandomString;

namespace UnitTests
{
    /// <summary>
    /// A character set that consists of one character.
    /// </summary>
    public sealed class SingleCharacterSetSpy : ICharacterSet
    {
        public SingleCharacterSetSpy(char expected)
        {
            Expected = expected;
        }

        public int Length => 1;

        public char Expected { get; }
        public int CallCount { get; private set; }

        /// <remarks>
        /// Only returns the value stored in the <see cref="Expected"/> property.
        /// </remarks>
        public char GetChar(int index)
        {
            CallCount++;

            return Expected;
        }
    }
}
