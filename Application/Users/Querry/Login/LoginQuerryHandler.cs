using Application.Common.Interface.Persistence;
using Application.Users.Common;
using Domain.Error;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Querry.Login
{
    public class LoginQuerryHandler : IRequestHandler<LoginQuerry, LoginResult>
    {
        private readonly IUserRepository _userRepo;

        public LoginQuerryHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<LoginResult> Handle(LoginQuerry request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.Login(request.email, request.password);
            if (user == null)
            {
                throw new InvalidCredentialException();
            }
            return new LoginResult(user.UserId);
        }
    }
}
