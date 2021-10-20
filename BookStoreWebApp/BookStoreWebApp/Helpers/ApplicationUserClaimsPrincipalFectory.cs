using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using System.Security.Claims;

namespace BookStoreWebApp.Helpers
{
    public class ApplicationUserClaimsPrincipalFectory : UserClaimsPrincipalFactory<ApplicationUserModel, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFectory(UserManager<ApplicationUserModel> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager,roleManager,options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUserModel user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            return identity;
        }
    }
}
