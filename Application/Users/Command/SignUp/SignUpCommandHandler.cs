using Application.Common.Interface.Persistence;
using Application.Users.Common;
using Domain.Entities;
using Domain.Error;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpResult>
    {
        private readonly IUserRepository _userRepo;

        public SignUpCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<SignUpResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepo.GetByEmailAsync(request.email);
            if(existUser != null)
            {
                throw new DuplicateEmailException();
            }
            var user = new User()
            {
                UserId = new Guid(),
                Avatar = "",
                Email = request.email,
                Password = request.password,
                Name = ""
            };
            await _userRepo.CreateUserAsync(user);
            return new SignUpResult(user.UserId);
        }
    }
}
