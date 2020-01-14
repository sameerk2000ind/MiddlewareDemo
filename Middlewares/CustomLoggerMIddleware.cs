using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    public class CustomLoggerMiddleware : ICustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomLoggerMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("CustomLoggerMIddleware");
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Log entry from CustomLogger.");
            await _next(context);
        }
    }
}
