using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBookStore.Api.IntegrationTest.Infrastructure
{
    internal class AutoAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public AutoAuthorizeMiddleware(RequestDelegate rd)
        {
            this._next = rd;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //create a fake identity to test the api
            if (httpContext.Request.Query.Keys.Count > 0)
            {
                var identity = new ClaimsIdentity("cookies");
                foreach (var key in httpContext.Request.Query.Keys)
                {
                    identity.AddClaim(new Claim(key, httpContext.Request.Query[key]));
                }
                httpContext.User.AddIdentity(identity);
            }
            await _next.Invoke(httpContext);
        }
    }
}