using System.Linq;
using System.Net;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Presentation.ResponseObjects;

namespace Presentation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILoggerService _logger;

        public ExceptionFilter(ILoggerService logger) => _logger = logger;

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            var exceptionType = context.Exception.GetType();
            var message = exceptionType.IsSubclassOf(typeof(DefaultException))
                ? context.Exception.Message
                : DefaultException.DefaultMessage;
            response.ContentType = "application/json";

            if (exceptionType.IsSubclassOf(typeof(EntidadeNaoEncontradaException)) || exceptionType == typeof(EntidadeNaoEncontradaException))
            {
                response.StatusCode = (int) HttpStatusCode.NotFound;
                response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse() {Message = message}));
                _logger.LogInfo(context.Exception, message);
            }
            else if (exceptionType.IsSubclassOf(typeof(EntidadeNaoProcessavelException)) || exceptionType == typeof(EntidadeNaoEncontradaException))
            {
                var exception = (EntidadeNaoProcessavelException) context.Exception;
                response.StatusCode = (int) HttpStatusCode.UnprocessableEntity;
                response.WriteAsync(
                    JsonConvert.SerializeObject(
                        new UnprocessableErrorResponse()
                        {
                            Message = exception.Message,
                            Errors = exception.Errors.ToDictionary(e => e.Nome,
                                e => exception.Errors.Where(err => err.Nome == e.Nome).Select(err => err.Mensagem)
                                    .ToArray())
                        }));
                _logger.LogInfo(exception, "{message}; Errors:{Errors}", message, exception.Errors.Select(e => e.Mensagem));
            }
            else
            {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse() {Message = message}));
                _logger.LogError(context.Exception, context.Exception.Message);
            }
        }
    }
}