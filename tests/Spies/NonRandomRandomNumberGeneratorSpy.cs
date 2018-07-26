using RandomString;

namespace UnitTests
{
    public sealed class NonRandomRandomNumberGeneratorSpy : IRandomNumberGenerator
    {
        public NonRandomRandomNumberGeneratorSpy(int expected)
        {
            Expected = expected;
        }
        public int Expected { get; private set; }
        public int CallCount { get; private set; }

        public int Next(int maxValue)
        {
            CallCount++;

            return Expected;
        }

    }
}
