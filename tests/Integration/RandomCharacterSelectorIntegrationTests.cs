using System;
using RandomString;
using Xunit;
using FluentAssertions;
using SecurityDriven.Inferno;

namespace UnitTests
{
    public class RandomCharacterSelectorIntegrationTests
    {
        private const string Symbols = "0123456789ABCDFGHJKLMNPQRSTVWXYZ";

        [Fact]
        public void CSPRING_Should_Generate_Token()
        {
            var selector = new RandomCharacterSelector(Symbols, new CryptoRandom());
            var generator = new RandomStringGenerator(selector);

            var token = generator.GenerateString(36);

            token.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void PRNG_Should_Generate_Token()
        {
            var selector = new RandomCharacterSelector(Symbols, new Random());
            var generator = new RandomStringGenerator(selector);

            var token = generator.GenerateString(36);

            token.Should().NotBeNullOrWhiteSpace();
        }
    }
}
