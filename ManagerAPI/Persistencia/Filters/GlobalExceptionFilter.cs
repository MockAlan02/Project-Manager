using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Persistencia.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var validation = new
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = exception.Message
            };
            var json = new
            {
                errors = new[] { validation }
            };
            context.Result = new ObjectResult(json)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
