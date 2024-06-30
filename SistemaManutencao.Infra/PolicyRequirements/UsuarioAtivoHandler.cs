using Microsoft.AspNetCore.Authorization;

namespace SistemaManutencao.Infra.Data.PolicyRequirements
{
    public class UsuarioAtivoHandler : AuthorizationHandler<UsuarioAtivoRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsuarioAtivoRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Ativo" && c.Value == "True"))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
