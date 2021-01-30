using Sandbox.Usr.WriteStack.Application.Commands.Dtos;

namespace Sandbox.Usr.WriteStack.Application.Commands.User.Dtos
{
    public class UserRequestDto : UserRequestDtoBase
    {
        public int StatusId { get; set; }
        public int RoleId { get; set; }
    }
}
