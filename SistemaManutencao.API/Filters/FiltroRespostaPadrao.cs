using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaManutencao.Application.Responses;

namespace SistemaManutencao.API.Filters
{
    public class FiltroRespostaPadrao : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var apiResponse = new RespostaBaseApi<object>
                {
                    Sucesso = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300,
                    Conteudo = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300 ? objectResult.Value : null,
                    Erros = objectResult.StatusCode >= 400 ? new List<string> { objectResult.Value?.ToString() } : null,
                    Mensagem = objectResult.StatusCode >= 400 ? "Erro geral" : null,
                    Total = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300 && objectResult.Value is IEnumerable<object> enumerable ? enumerable.Count() : (int?)null
                };

                context.Result = new ObjectResult(apiResponse)
                {
                    StatusCode = objectResult.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
