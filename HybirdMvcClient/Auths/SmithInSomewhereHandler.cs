using System.Linq;
using System.Threading.Tasks;
using HybirdMvcClient.Requirements;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace HybirdMvcClient.Auths
{
    public class SmithInSomewhereHandler : AuthorizationHandler<SmithInSomewhereRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            SmithInSomewhereRequirement requirement)
        {
            //var filterContext = context.Resource as AuthorizationFilterContext;
            //if (filterContext == null)
            //{
            //    context.Fail();
            //    return Task.CompletedTask;
            //}

            var role = context.User.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Role)?.Value;
            var location = context.User.Claims.FirstOrDefault(c => c.Type == "location")?.Value;

            if (role == "guest" && location == "somewhere" && context.User.Identity.IsAuthenticated)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;

            // 一个Handler成功，其它的Handler没有失败 => Requirement被满足了
            // 某个Hanlder失败 => 无法满足Requirement
            // 没有成功和失败 => 无法满足Requirement
        }
    }
}
