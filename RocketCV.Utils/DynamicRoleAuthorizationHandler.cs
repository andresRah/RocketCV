using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketCV.Utils
{
    public class DynamicRoleRequirement : IAuthorizationRequirement
    {
        // Custom requirement properties and methods
    }

    public class DynamicRoleAuthorizationHandler : AuthorizationHandler<DynamicRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicRoleRequirement requirement)
        {
            // Logic to validate the user's role
            // You can access user claims through context.User

            // Example: Check if the user has the "ADMIN" role
            if (context.User.IsInRole("ADMIN"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}
