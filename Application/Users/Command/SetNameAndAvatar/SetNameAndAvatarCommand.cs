using Application.Users.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.SetNameAndAvatar
{
    public record SetNameAndAvatarCommand(Guid userId, string name, string avatar) : IRequest<SetNameAndAvatarResult>;
}
