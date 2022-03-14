using FluentValidation;
using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Common.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchClothes.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case InvalidPasswordException invalidPasswordException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case InvalidVerificationCode invalidVerificationCode:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case PostAlreadyExistsException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case EditingNotUserOwnPostException:
                    code = HttpStatusCode.Forbidden;
                    break;
                case UserNotFoundException userNotFoundException:
                case PostNotFoundException post:
                    code = HttpStatusCode.NotFound;
                    break;
                //TODO: add other exceptions!
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
