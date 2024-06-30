using Microsoft.AspNetCore.Authorization;

namespace SistemaManutencao.Infra.Data.PolicyRequirements
{
    public class UsuarioFuncionarioHandler : AuthorizationHandler<UsuarioFuncionarioRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsuarioFuncionarioRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Funcionario" && c.Value == "True"))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
    {
    }
}
