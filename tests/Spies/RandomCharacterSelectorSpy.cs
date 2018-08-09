using RandomString;

namespace UnitTests
{
    public sealed class RandomCharacterSelectorSpy : IRandomCharacterSelector
    {
        public RandomCharacterSelectorSpy(char expected)
        {
            Expected = expected;
        }
        public char Expected { get; }
        public int CallCount { get; private set; }
        
        public char Next()
        {
            CallCount++;

            return Expected;
        }
    }
}
