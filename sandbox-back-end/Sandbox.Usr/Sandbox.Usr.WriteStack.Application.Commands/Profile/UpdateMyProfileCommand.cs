using Common.Application.Cqs.Contracts;
using Sandbox.Usr.WriteStack.Application.Commands.Profile.Dtos;

namespace Sandbox.Usr.WriteStack.Application.Commands.Profile
{
    public class UpdateMyProfileCommand : ICommand
    {
        public ProfileRequestDto MyProfileRequestDto { get; }

        public UpdateMyProfileCommand(ProfileRequestDto myProfileRequestDto)
        {
            MyProfileRequestDto = myProfileRequestDto;
        }
    }
}
