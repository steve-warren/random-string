using RandomString;
using System;
using Xunit;

namespace UnitTests
{
    public class RandomStringGeneratorUnitTests
    {                
        [Fact]
        public void Length_Of_Zero_Throws_Arg_Exception()
        {
            var generator = new RandomStringGenerator(new NonRandomRandomNumberGeneratorSpy(expected: 0), new SingleCharacterSetSpy(expected: 'a'));

            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateString(0));
        }

        [Fact]
        public void Length_Of_Negative_Number_Throws_Arg_Exception()
        {
            var generator = new RandomStringGenerator(new NonRandomRandomNumberGeneratorSpy(expected: 0), new SingleCharacterSetSpy(expected: 'a'));

            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateString(-1));
        }

        [Fact]
        public void Should_Return_String_Of_Correct_Length()
        {
            var generator = new RandomStringGenerator(new NonRandomRandomNumberGeneratorSpy(expected: 0), new SingleCharacterSetSpy(expected: 'a'));
            var length = 10;

            Assert.Equal(length, generator.GenerateString(length).Length);
        }

        [Fact]
        public void Rng_Call_Count_Should_Equal_Length_Of_String()
        {
            var expected = 5;

            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var generator = new RandomStringGenerator(rng, new SingleCharacterSetSpy(expected: 'a'));

            generator.GenerateString(expected);

            Assert.Equal(expected, rng.CallCount);
        }

        [Fact]
        public void CharacterSet_Call_Count_Should_Equal_Length_Of_String()
        {
            var expected = 5;

            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var characters = new SingleCharacterSetSpy(expected: 'a');
            var generator = new RandomStringGenerator(rng, characters);

            generator.GenerateString(expected);

            Assert.Equal(expected, characters.CallCount);
        }

        [Fact]
        public void Random_Number_Should_Be_One_Fewer_Of_Character_Set_Length()
        {
            var rng = new NonRandomRandomNumberGeneratorSpy(expected: 0);
            var characters = new SingleCharacterSetSpy(expected: 'a');
            var generator = new RandomStringGenerator(rng, characters);

            generator.GenerateString(1);

            Assert.Equal(rng.Length - 1, rng.CapturedMaxValue);
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
            
            var expected = "aaaaa";
            var actual = generator.GenerateString(expected.Length);

            Assert.Equal(expected, actual);
        }
    }
}
