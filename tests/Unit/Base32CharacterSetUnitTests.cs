using RandomString;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class Base32CharacterSetUnitTests
    {
        [Fact]
        public void Should_Return_All_Unique_Chars_In_Set()
        {
            var characters = new Base32CharacterSet();

            var chars = new HashSet<char>();

            for (var i = 0; i < characters.Length; i ++)
                chars.Add(characters.GetChar(i));

            Assert.Equal(characters.Length, chars.Count);
        }

        [Fact]
        public void Should_Throw_With_Negative_Index_Value()
        {
            var characters = new Base32CharacterSet();

            Assert.Throws<ArgumentOutOfRangeException>(() => characters.GetChar(-1));
        }

        [Fact]
        public void Should_Throw_When_Index_Value_Above_Char_Count()
        {
            var characters = new Base32CharacterSet();

            Assert.Throws<ArgumentOutOfRangeException>(() => characters.GetChar(characters.Length));
        }
    }
}
