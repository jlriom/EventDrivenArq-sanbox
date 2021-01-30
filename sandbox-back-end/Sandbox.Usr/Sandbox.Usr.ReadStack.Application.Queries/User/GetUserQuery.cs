using Common.Application.Cqs.Contracts;
using Sandbox.Usr.ReadStack.Application.Queries.User.Dtos;
using System;

namespace Sandbox.Usr.ReadStack.Application.Queries.User
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public Guid Id { get; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
}