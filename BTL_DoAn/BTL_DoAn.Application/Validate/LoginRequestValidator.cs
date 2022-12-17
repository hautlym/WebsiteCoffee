﻿
using BTL_DoAn.Application.Catalog.System.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Application.Validate
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Vui lòng điền tài khoản");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Vui lòng điền mật khẩu");
        }
    }
}
