using RandomString;
using System;
using Xunit;
using FluentAssertions;

namespace UnitTests
{
    public class RandomStringGeneratorUnitTests
    {                
        [Fact]
        public void Length_Of_Zero_Throws_Arg_Exception()
        {
            var generator = new RandomStringGenerator(new NonRandomRandomNumberGeneratorSpy(expected: 0), new SingleCharacterSetSpy(expected: 'a'));

            ((Action) (() => generator.GenerateString(0))).Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Length_Of_Negative_Number_Throws_Arg_Exception()
        {
            var generator = new RandomStringGenerator(new NonRandomRandomNumberGeneratorSpy(expected: 0), new SingleCharacterSetSpy(expected: 'a'));

            ((Action) (() => generator.GenerateString(-1))).Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Return_String_Of_Correct_Length()
        {
            var generator = new RandomStringGenerator(new NonRandomRandomNumberGeneratorSpy(expected: 0), new SingleCharacterSetSpy(expected: 'a'));
            var length = 10;

            generator.GenerateString(length).Length.Should().Be(length);
        }

        [Fact]
        public void Rng_Call_Count_Should_Equal_Length_Of_String()
        {
            var expected = 5;

            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var generator = new RandomStringGenerator(rng, new SingleCharacterSetSpy(expected: 'a'));

            generator.GenerateString(expected);

            rng.CallCount.Should().Be(expected);
        }

        [Fact]
        public void CharacterSet_Call_Count_Should_Equal_Length_Of_String()
        {
            var expected = 5;

            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var characters = new SingleCharacterSetSpy(expected: 'a');
            var generator = new RandomStringGenerator(rng, characters);

            generator.GenerateString(expected);

            characters.CallCount.Should().Be(expected);
        }

        [Fact]
        public void Rng_Expects_Maximum_Value_To_Be_Length_Of_CharacterSet()
        {
            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var characters = new SingleCharacterSetSpy(expected: 'a');
            var generator = new RandomStringGenerator(rng, characters);

            generator.GenerateString(1);

            rng.CapturedMaxValue.Should().Be(0);
        }

        [Fact]
        public void Character_Set_Expects_Same_Number_Returned_By_Rng()
        {
            // rng will always return as the number
            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);

            // set will always return 'a'
            var characters = new SingleCharacterSetSpy(expected: 'a');

            var generator = new RandomStringGenerator(rng, characters);

            generator.GenerateString(1);

            characters.CapturedIndexValue.Should().Be(0);
        }

        [Fact]
        public void Should_Use_Characters_From_CharacterSet()
        {
            // in this setup, the rng will always return 0.
            // The random string generator should pass 0 to
            // the character set, which then returns the char 'a'
            // located at index 0.

            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var characters = new SingleCharacterSetSpy(expected: 'a');
            var generator = new RandomStringGenerator(rng, characters);
            
            var randomString = generator.GenerateString(5);

            randomString.Should().Be("aaaaa");
        }
    }
}
