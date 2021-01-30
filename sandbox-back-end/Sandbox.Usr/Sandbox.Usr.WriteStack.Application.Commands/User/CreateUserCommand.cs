using Common.Application.Cqs.Contracts;
using Sandbox.Usr.WriteStack.Application.Commands.User.Dtos;

namespace Sandbox.Usr.WriteStack.Application.Commands.User
{
    public class CreateUserCommand : ICommand
    {
        public UserRequestDto UserRequestDto { get; }

        public CreateUserCommand(UserRequestDto userRequestDto)
        {
            UserRequestDto = userRequestDto;
        }
    }
}
