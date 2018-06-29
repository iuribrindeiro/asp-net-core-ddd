using System.Linq;
using System.Net;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Presentation.ResponseObjects;

namespace Presentation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        //private readonly ILogger _logger;

        //public ExceptionFilter(ILogger logger) => _logger = logger;

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            var exceptionType = context.Exception.GetType();
            var message = exceptionType.IsSubclassOf(typeof(DefaultException))
                ? context.Exception.Message
                : DefaultException.DefaultMessage;
            response.ContentType = "application/json";

            if (exceptionType == typeof(EntidadeNaoEncontradaException))
            {
                response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse() {Message = message}));
                response.StatusCode = (int) HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(EntidadeNaoProcessavelException))
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
            }
            else
            {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse() {Message = message}));
            }
        }
    }
}