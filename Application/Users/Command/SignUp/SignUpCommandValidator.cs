using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.SignUp
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(p => p.email).NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Sai định dạng email");

            RuleFor(p => p.password).NotEmpty().WithMessage("Mật khẩu không được để trống");
        }
    }
}
