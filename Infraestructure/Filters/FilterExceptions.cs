using Core.Exceptions;
using Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;


namespace Infraestructure.Filters
{
    public class FilterExceptions : ExceptionFilterAttribute
    {
        public readonly IAdminInterfaces _adminInterfaces;

        public FilterExceptions(IAdminInterfaces adminInterfaces)
        {
            _adminInterfaces = adminInterfaces;
        }

        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode Status = HttpStatusCode.InternalServerError;
            string Title = string.Empty;
            string Detail = string.Empty;

            if (context.Exception.GetType() == typeof(UnauthorizedBusinessException))
            {
                var exception = (UnauthorizedBusinessException)context.Exception;
                Status = HttpStatusCode.Unauthorized;
                Title = string.IsNullOrEmpty(exception.exception?.Name) ? $"Unauthorized {context.ActionDescriptor.DisplayName}" : $"{exception.exception.Name} {context.ActionDescriptor.DisplayName}";
                Detail = string.IsNullOrEmpty(exception.Message) ? exception.exception.Message : exception.Message;
            }
            if (context.Exception.GetType() == typeof(InternalServerErrorBusinessExceprions))
            {
                var exception = (InternalServerErrorBusinessExceprions)context.Exception;
                Status = HttpStatusCode.InternalServerError;
                Title = string.IsNullOrEmpty(exception.exception?.Name) ? $"Internal Server Error {context.ActionDescriptor.DisplayName}" : $"Not name";
                Detail = string.IsNullOrEmpty(exception.Message) ? exception.exception.Message : exception.Message;
            }
            if (context.Exception.GetType() == typeof(BadRequestBusinessException))
            {
                var exception = (BadRequestBusinessException)context.Exception;
                Status = HttpStatusCode.BadRequest;
                Title = string.IsNullOrEmpty(exception.exception?.Name) ? $"BadRequest Server Error {context.ActionDescriptor.DisplayName}" : $"Not name";
                Detail = string.IsNullOrEmpty(exception.Message) ? exception.exception.Message : exception.Message;
            }
            if (context.Exception.GetType() == typeof(ConnectionBusinessException))
            {
                var exception = (ConnectionBusinessException)context.Exception;
                Status = HttpStatusCode.BadRequest;
                Title = "Connect Error ";
                Detail = string.IsNullOrEmpty(exception.Message) ? exception.exception.Message : exception.Message;
            }
            var objectException = new
            {
                Status,
                Title,
                Detail
            };

            var json = new
            {
                errors = new[] { objectException }
            };

            context.Result = new JsonResult(json);
            context.HttpContext.Response.StatusCode = (int)Status;
            context.ExceptionHandled = true;
        }
    }
}
