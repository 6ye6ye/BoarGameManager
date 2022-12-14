using AutoMapper;
using BoardGameManager1.Common.Exceptions;
using DAL.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace BoardGameManager1.Extensions
{


    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;
        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            var exceptionType = exception.GetType();
            stackTrace = exception.StackTrace;

            string message = exception.Message;
            switch (exceptionType.Name)
            {
                case nameof(NotFoundException):
                    {
                        status = HttpStatusCode.NotFound;
                        logger.LogError(message, stackTrace);
                        break;
                    }
                case nameof(DoublicateException):
                    {
                        status = HttpStatusCode.Conflict;
                        break;
                    }
                case nameof(AutoMapperMappingException):
                    {
                        message = "Mapper Error";
                        status = HttpStatusCode.Conflict;
                        logger.LogError(message, stackTrace);
                        break;
                    }
                case nameof(NotImplementedException):
                    {
                        status = HttpStatusCode.NotImplemented;
                        logger.LogError(message, stackTrace);
                        break;
                    }
                case nameof(KeyNotFoundException):
                    {
                        status = HttpStatusCode.Unauthorized;
                        logger.LogError(message, stackTrace);
                        break;
                    }
                case nameof(UnauthorizedAccessException):
                    {
                        message = "Unauthorized";
                        status = HttpStatusCode.Unauthorized;
                        logger.LogError(message, stackTrace);
                        break;
                    }
                default:
                    {
                        status = HttpStatusCode.InternalServerError;
                        logger.LogError(message, stackTrace);
                        break;
                    }
            }
   
             

            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(message);
        }

    }
}
