using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ComexApi.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var birthClaim = context
            .User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (birthClaim is null)
        {
            return Task.CompletedTask;
        }

        var userBith = Convert.ToDateTime(birthClaim.Value);

        var ageActs = DateTime.Today.Year - userBith.Year;

        if (userBith > DateTime.Today.AddYears(-ageActs))
        {
            ageActs--;
        }

        if (ageActs >= requirement.Idade) { 
            context.Succeed(requirement);
        
        }

        return Task.CompletedTask;
    }
}
