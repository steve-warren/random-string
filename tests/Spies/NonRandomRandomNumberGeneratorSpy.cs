using RandomString;

namespace UnitTests
{
    public sealed class NonRandomRandomNumberGeneratorSpy : IRandomNumberGenerator
    {
        public NonRandomRandomNumberGeneratorSpy(int expected)
        {
            Expected = expected;
        }
        public int Expected { get; }
        public int CallCount { get; private set; }
        public int CapturedMaxValue { get; private set; } = -1;

        public int Next(int maxValue)
        {
            CapturedMaxValue = maxValue;
            CallCount++;

            return Expected;
        }

    }
}
