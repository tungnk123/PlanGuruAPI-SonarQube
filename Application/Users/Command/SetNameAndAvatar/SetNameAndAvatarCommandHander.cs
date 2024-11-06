using Application.Common.Interface.Persistence;
using Application.Users.Common;
using Domain.Error;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.SetNameAndAvatar
{
    public class SetNameAndAvatarCommandHander : IRequestHandler<SetNameAndAvatarCommand, SetNameAndAvatarResult>
    {
        private readonly IUserRepository _userRepo;

        public SetNameAndAvatarCommandHander(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<SetNameAndAvatarResult> Handle(SetNameAndAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByIdAsync(request.userId);  
            if(user == null)
            {
                throw new NotFoundException();
            }
            user.Avatar = request.avatar;
            user.Name = request.name;   
            await _userRepo.UpdateAsync(user);
            return new SetNameAndAvatarResult("Set name and avatar successfully"); 
        }
    }
}
