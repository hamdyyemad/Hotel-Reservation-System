using HotelBooking.Domain.Enums;
using HotelBooking.Domain.Models.ViewModels;
using System.Net;
using System.Text.Json;

namespace HotelBooking.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorCode = exception.Data.Contains("ErrorCode")
                ? (ErrorCode)exception.Data["ErrorCode"]
                : ErrorCode.SomethingWentWrong;

            var errorResponse = new ErrorResponseViewModel(exception.Message, errorCode);

            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}