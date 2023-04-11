using Api.Crud.Domain.Login;
using Api.Crud.Domain.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Validator.Login;

public class RequestLoginValidator : AbstractValidator<RequestLogin>
{

    public RequestLoginValidator()
    {
        RuleFor(x => x.Login)
                .NotNull().WithMessage("Faltando.")
                .NotEmpty().WithMessage("Deve ser informado.")
                .NotEqual("string").WithMessage("Inválido.")
                .EmailAddress().WithMessage("Email Inválido");

        RuleFor(x => x.Senha)
                .NotNull().WithMessage("faltando.")
                .NotEmpty().WithMessage("Deve ser informado.")
                .NotEqual("string").WithMessage("Inválido.")
                .MaximumLength(51).WithMessage("máximo permitido de 51 caracteres");
    }
}
