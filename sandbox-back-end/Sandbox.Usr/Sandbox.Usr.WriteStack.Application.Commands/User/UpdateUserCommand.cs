using Common.Application.Cqs.Contracts;
using Sandbox.Usr.WriteStack.Application.Commands.User.Dtos;
using System;

namespace Sandbox.Usr.WriteStack.Application.Commands.User
{
    public class UpdateUserCommand : ICommand
    {
        public Guid Id { get; }
        public UserRequestDto UserRequestDto { get; }

        public UpdateUserCommand(Guid id, UserRequestDto userRequestDto)
        {
            Id = id;
            UserRequestDto = userRequestDto;
        }
    }
}
