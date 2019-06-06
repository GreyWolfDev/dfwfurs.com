using System;
using System.Threading.Tasks;
using DFW.Furs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace DFW.Furs.Web.Security
{
    public class SecurePolicy : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider defaultPolicyProvider { get; }
        public SecurePolicy(IOptions<AuthorizationOptions> options)
        {
            defaultPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return defaultPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            string[] subStringPolicy = policyName.Split(new char[] { '.' });
            
            if (subStringPolicy.Length > 1 && subStringPolicy[0].Equals("Role", StringComparison.OrdinalIgnoreCase) && Enum.TryParse(typeof(Role), subStringPolicy[1], false, out var role))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new SecureRequirement((Role)role));
                return Task.FromResult(policy.Build());
            }
            return defaultPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
