using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace WebServiceSimple.Middleware
{
    public class AuthService
    {
        private readonly RequestDelegate _next;

        public AuthService(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IDataService dataService)
        {
            Program.CurrentUser = null;
            var auth = context.Request.Headers["Authorization"];
            if (auth != StringValues.Empty)
            {
                Program.CurrentUser = dataService.GetUser(auth);
            }

            await _next(context);
        }
    }
}
