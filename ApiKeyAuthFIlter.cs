using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assessment
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly string _apiKey;

        public ApiKeyAuthFilter(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Get the API key from the request header.
            string? apiKeyFromHeader = context.HttpContext.Request.Headers["X-API-Key"];

            // Validate the API key.
            if (apiKeyFromHeader != _apiKey)
            {
                // Deny access.
                context.Result = new UnauthorizedResult();
            }
        }
    }
}