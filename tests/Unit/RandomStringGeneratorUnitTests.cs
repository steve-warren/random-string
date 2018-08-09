using RandomString;
using System;
using Xunit;
using FluentAssertions;

namespace UnitTests
{
    public class RandomStringGeneratorUnitTests
    {                
        [Fact]
        public void Request_Token_Of_Zero_Length_Throws_Arg_Exception()
        {
            var generator = new RandomStringGenerator(new RandomCharacterSelectorSpy(expected: 'a'));

            ((Action) (() => generator.GenerateString(0))).Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Request_Token_Of_Negative_Length_Throws_Arg_Exception()
        {
            var generator = new RandomStringGenerator(new RandomCharacterSelectorSpy(expected: 'a'));

            ((Action) (() => generator.GenerateString(-1))).Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Token_Length_Should_Match_Requested_Length()
        {
            var generator = new RandomStringGenerator(new RandomCharacterSelectorSpy(expected: 'a'));
            var length = 10;

            generator.GenerateString(length).Length.Should().Be(length);
        }

        [Fact]
        public void Token_Should_Contain_Characters_From_Picker()
        {
            var generator = new RandomStringGenerator(new RandomCharacterSelectorSpy(expected: 'a'));

            var randomString = generator.GenerateString(5);

            randomString.Should().Be("aaaaa");
        }

        [Fact]
        public void Calls_To_Picker_Should_Match_Requested_Length_Of_Token()
        {
            var expected = 5;

            var selector = new RandomCharacterSelectorSpy(expected: 'a');
            var generator = new RandomStringGenerator(selector);

            generator.GenerateString(expected);

            selector.CallCount.Should().Be(expected);
        }
    }
}
