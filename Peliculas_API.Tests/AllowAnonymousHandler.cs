using Microsoft.AspNetCore.Authorization;

namespace Peliculas_API.Tests
{
    public class AllowAnonymousHandler : IAuthorizationHandler
    {
        // Se va a saltar todas las medidas de seguridad
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var requirement in context.PendingRequirements.ToList())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
