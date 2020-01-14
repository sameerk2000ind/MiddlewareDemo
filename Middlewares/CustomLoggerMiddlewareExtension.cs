using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    public static class CustomLoggerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLoggerMiddleware>();
        }
    }
}
