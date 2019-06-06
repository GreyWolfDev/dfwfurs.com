using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using DFW.Furs.Models;
using DFW.Furs.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;

namespace DFW.Furs.Web.Security
{
    public class SecureHandler : AuthorizationHandler<SecureRequirement>
    {
        DFWDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        public SecureHandler(IHttpContextAccessor accessor, DFWDbContext context)
        {
            _accessor = accessor;
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SecureRequirement requirement)
        {
            var hash = _accessor.HttpContext.Request.Cookies["telegram-login"];
            var user = _context.Authentications.FirstOrDefault(x => x.hash == hash);
            if (user == null)
            {
                return Task.FromResult(0);
            }

            var member = _context.CrewMembers.FirstOrDefault(x => x.TelegramId == user.telegram_id);
            if (member != null)
            {
                if (member.Roles.HasFlag(requirement.Role) || member.Roles.HasFlag(Role.Developer))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.FromResult(0);
        }
    }
}
