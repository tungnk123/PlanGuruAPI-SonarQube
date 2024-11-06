using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Querry
{
    public class LoginQuerryValidator : AbstractValidator<LoginQuerry>
    {
        public LoginQuerryValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.password).NotEmpty().WithMessage("Mật khẩu không được để trống");
        }
    }
}
