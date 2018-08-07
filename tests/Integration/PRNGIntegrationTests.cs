using RandomString;
using Xunit;
using FluentAssertions;

namespace UnitTests
{
    public class PRNGIntegrationTests
    {
        [Fact]
        public void Token_Should_Not_Be_Null_Or_Empty()
        {
            var rng = new CryptoRandomNumberGenerator();
            var characters = new Base32CharacterSet();
            var generator = new RandomStringGenerator(rng, characters);

            var token = generator.GenerateString(36);

            token.Should().NotBeNullOrWhiteSpace();
        }
    }
}
