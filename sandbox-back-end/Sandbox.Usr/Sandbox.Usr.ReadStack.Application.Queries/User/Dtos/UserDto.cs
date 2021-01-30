using System;

namespace Sandbox.Usr.ReadStack.Application.Queries.User.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StatusDto Status { get; set; }
        public RoleDto Role { get; set; }

        public UserDto(
            Guid id,
            DateTime createdOn,
            string email,
            string firstName,
            string lastName,
            StatusDto status,
            RoleDto role)
        {
            Id = id;
            CreatedOn = createdOn;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
            Role = role;
        }

    }
}