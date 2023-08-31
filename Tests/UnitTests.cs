using NUnit.Framework;

namespace Assessment.Tests
{
    public class UnitTests
    {
        private ApiKeyAuthFilter filter;

        public UnitTests()
        {
            string apiKey = "my-secret-api-key";
            filter = new ApiKeyAuthFilter(apiKey);
        }

        // Test that the ApiKeyAuthFilter can be created.
        [Test]
        public void ApiKeyAuthFilterCanBeCreated()
        {
            // Arrange.
            string apiKey = "my-secret-api-key";

            // Act.
            ApiKeyAuthFilter filter = new ApiKeyAuthFilter(apiKey);

            // Assert.
            Assert.NotNull(filter);
        }
    }       
}