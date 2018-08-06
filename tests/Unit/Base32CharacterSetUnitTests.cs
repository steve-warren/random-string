using RandomString;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

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

            chars.Should().HaveCount(characters.Length);
        }

        [Fact]
        public void Should_Throw_With_Negative_Index_Value()
        {
            var characters = new Base32CharacterSet();

            ((Action) (() => characters.GetChar(-1))).Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_When_Index_Value_Above_Char_Count()
        {
            var characters = new Base32CharacterSet();

            ((Action)(() => characters.GetChar(characters.Length))).Should().ThrowExactly<ArgumentOutOfRangeException>();
        }
    }
}
