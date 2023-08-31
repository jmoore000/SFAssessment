using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Net;
using System.Net.Http;

namespace Assessment.Tests
{
    public class IntegrationTests
    {
        [Test]
        public void ApiKeyAuthFilterCanProtectEndpoint()
        {
            // Arrange.
            string apiKey = "my-secret-api-key";
            ApiKeyAuthFilter filter = new ApiKeyAuthFilter(apiKey);

            // Create a test server.
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            // Check the return type of the CreateHttpClient method.
            Type returnType = server.GetType().GetMethod("CreateHttpClient").ReturnType;
            if (returnType != typeof(HttpClient))
            {
                // The CreateHttpClient method does not return an HttpClient object.
                // Handle this error as appropriate for your application.
                throw new Exception("The CreateHttpClient method does not return an HttpClient object.");
            }

            // Create an HttpClient object using the CreateHttpClient method.
            var client = (HttpClient)server.GetType().GetMethod("CreateHttpClient").Invoke(server, null);

            // Act.
            //var client = server.CreateHttpClient();
            var response = client.GetAsync("/").Result;

            // Assert.
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public void ApiKeyAuthFilterCanDenyAccessToEndpointWithInvalidApiKey()
        {
            // Arrange.
            string apiKey = "invalid-api-key";
            ApiKeyAuthFilter filter = new ApiKeyAuthFilter(apiKey);

            // Create a test server.
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            // Check the return type of the CreateHttpClient method.
            Type returnType = server.GetType().GetMethod("CreateHttpClient").ReturnType;
            if (returnType != typeof(HttpClient))
            {
                // The CreateHttpClient method does not return an HttpClient object.
                // Handle this error as appropriate for your application.
                throw new Exception("The CreateHttpClient method does not return an HttpClient object.");
            }

            // Create an HttpClient object using the CreateHttpClient method.
            var client2 = (HttpClient)server.GetType().GetMethod("CreateHttpClient").Invoke(server, null);

                       var response = client2.GetAsync("/").Result;

            // Assert.
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}