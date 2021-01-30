using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Common.Core
{
    public class UserFactory
    {


        public User Create(IPrincipal principal)
        {
            var claimsPrincipal = principal as ClaimsPrincipal;
            if (claimsPrincipal == null)
            {
                return null;
            }

            var subClaims = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "sub");
            var tokenClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "token");
            var emailClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "email");
            if (subClaims == null || tokenClaim == null || emailClaim == null)
            {
                return null;
            }

            return new User
            {
                Id = new Guid(subClaims.Value),
                Token = tokenClaim.Value,
                Email = emailClaim.Value
            };

        }
    }
}
