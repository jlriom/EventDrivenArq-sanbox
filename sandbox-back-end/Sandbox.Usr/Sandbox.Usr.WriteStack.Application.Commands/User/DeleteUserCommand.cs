using Common.Application.Cqs.Contracts;
using System;

namespace Sandbox.Usr.WriteStack.Application.Commands.User
{
    public class DeleteUserCommand : ICommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}
