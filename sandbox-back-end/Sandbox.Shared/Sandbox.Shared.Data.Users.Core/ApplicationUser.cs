using Microsoft.AspNetCore.Identity;
using System;

namespace Sandbox.Shared.Data.Users.Core
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
