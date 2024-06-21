using System.Net;
using System.Text.Json;
using FluentValidation;
using SistemaManutencao.Application.Responses;
using SistemaManutencao.Domain.Exceptions;

namespace SistemaManutencao.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");

            var response = context.Response;
            response.ContentType = "application/json";

            var apiResponse = new RespostaBaseApi<object>
            {
                Sucesso = false,
                Mensagem = exception.Message,
                Erros = new List<string> { exception.InnerException?.Message ?? exception.Message }
            };

            switch (exception)
            {
                case ValidationException validationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResponse.Erros = validationException.Errors.Select(e => e.ErrorMessage).ToList();
                    break;
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    apiResponse.Mensagem = "Recurso não encontrado";
                    break;
                case EntidadeNaoEncontradaException entidadeNaoEncontradaException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    apiResponse.Mensagem = entidadeNaoEncontradaException.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    apiResponse.Mensagem = "Erro interno no servidor";
                    break;
            }

            var result = JsonSerializer.Serialize(apiResponse);
            return response.WriteAsync(result);
        }
    }
}
