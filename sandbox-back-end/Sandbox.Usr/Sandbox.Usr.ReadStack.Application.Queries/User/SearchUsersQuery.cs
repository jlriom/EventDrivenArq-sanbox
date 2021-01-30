using Common.Application.Cqs.Implementation;
using Sandbox.Usr.ReadStack.Application.Queries.User.Dtos;

namespace Sandbox.Usr.ReadStack.Application.Queries.User
{
    public class SearchUsersQuery : PagedQuery<UserDto>
    {
        public SearchUsersQuery(int limit, int offset) : base(limit, offset)
        {
        }
    }
}