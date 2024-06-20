using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using SistemaManutencao.Application.Responses;

namespace SistemaManutencao.API.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                var errors = validationException.Errors.Select(e => e.ErrorMessage).ToList();

                var apiResponse = new RespostaBaseApi<object>
                {
                    Sucesso = false,
                    Erros = errors,
                    Mensagem = "Erro de validação"
                };

                context.Result = new ObjectResult(apiResponse)
                {
                    StatusCode = 400
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
