using System;

namespace Sandbox.Usr.ReadStack.Application.Queries.Profile.Dtos
{
    public class ProfileDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
