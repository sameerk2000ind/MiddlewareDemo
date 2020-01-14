using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Filters
{
    public class CustomAuthorization : ActionFilterAttribute
    {
        private readonly ApiSettings _apiSettings;
        
        public CustomAuthorization(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authKeyName = "apikey";
            var headers = context.HttpContext.Request.Headers;

            if(headers.Keys.Contains(authKeyName))
            {
                var header = headers.FirstOrDefault(x => x.Key == authKeyName).Value.FirstOrDefault();
                if(_apiSettings.ApiKey != header)
                {
                    context.Result = new ContentResult()
                    {
                        Content = "Authentication Failed.",
                        ContentType = "text/plain",
                        StatusCode = 401

                    };
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
