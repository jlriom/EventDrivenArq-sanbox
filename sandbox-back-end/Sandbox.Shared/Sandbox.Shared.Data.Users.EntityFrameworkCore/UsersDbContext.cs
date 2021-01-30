using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sandbox.Shared.Data.Users.Core;

namespace Sandbox.Shared.Data.Users.EntityFrameworkCore
{
    public class UsersDbContext : IdentityDbContext<ApplicationUser>
    {

        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }
    }
}
