using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace BookManagement.CustomAttributes
{
    public class ApiKeyAttribute : Attribute, IActionFilter
    {
        private const string apiKeyName = "APIToken";
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(apiKeyName, out var ApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode =(int)HttpStatusCode.Unauthorized,
                    Content = "API token is unavailable in the request."
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var key = appSettings.GetValue<string>(apiKeyName);
            if (!key.Equals(ApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Content = "Invalid API token."
                };
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
