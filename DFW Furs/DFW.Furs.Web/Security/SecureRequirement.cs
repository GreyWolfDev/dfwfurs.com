using DFW.Furs.Database;
using DFW.Furs.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFW.Furs.Web.Security
{
    public class SecureRequirement : IAuthorizationRequirement
    {
        public SecureRequirement(Role role)
        {
            Role = role;
        }
        public Role Role { get; private set; }
    }
}
