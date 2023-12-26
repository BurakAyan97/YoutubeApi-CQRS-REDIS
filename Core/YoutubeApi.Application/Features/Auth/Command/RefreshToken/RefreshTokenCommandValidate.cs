using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidate : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidate()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
            RuleFor(x => x.AccessToken).NotEmpty();
        }
    }
}
