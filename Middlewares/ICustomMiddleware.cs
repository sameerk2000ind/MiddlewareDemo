using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    public interface ICustomMiddleware
    {
        public Task Invoke(HttpContext context);
    }
}
