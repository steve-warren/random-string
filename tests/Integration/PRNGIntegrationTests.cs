using RandomString;
using Xunit;

namespace UnitTests
{
    public class PRNGIntegrationTests
    {
        [Fact]
        public void Token_Should_Not_Be_Null_Or_Empty()
        {
            var rng = new PRNGRandomNumberGenerator();
            var characters = new DefaultCharacterSet();
            var generator = new RandomStringGenerator(rng, characters);

            var token = generator.GenerateString(36);

            Assert.False(string.IsNullOrWhiteSpace(token));
        }
    }
}
