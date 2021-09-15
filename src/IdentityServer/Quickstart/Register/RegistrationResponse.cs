using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.PasswordReset
{
    public class RegistrationResponse
    {
        public IdentityResult Result { get; set; }

        public ApplicationUser? User { get; set; }
        public RegistrationResponse(IdentityResult result)
        {
            Result = result;
            User = null; 
        }

        public RegistrationResponse(IdentityResult result, ApplicationUser user)
        {
            Result = result;
            User = user;
        }
    }
}
