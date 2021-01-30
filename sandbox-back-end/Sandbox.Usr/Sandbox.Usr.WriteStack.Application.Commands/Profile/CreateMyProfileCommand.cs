using Common.Application.Cqs.Contracts;
using Sandbox.Usr.WriteStack.Application.Commands.Profile.Dtos;

namespace Sandbox.Usr.WriteStack.Application.Commands.Profile
{
    public class CreateMyProfileCommand : ICommand
    {
        public ProfileRequestDto MyProfileRequestDto { get; }

        public CreateMyProfileCommand(ProfileRequestDto myProfileRequestDto)
        {
            MyProfileRequestDto = myProfileRequestDto;
        }
    }
}
