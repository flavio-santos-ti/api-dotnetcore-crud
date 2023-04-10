using Api.Crud.Domain.Create;
using Api.Crud.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Api.Crud.Business.Validator.Usuario;

public class UsuarioCreateValidator : AbstractValidator<UsuarioCreate>
{
    public UsuarioCreateValidator()
    {
        RuleFor(x => x.Nome)
            .NotNull().WithMessage("faltando.")
            .NotEmpty().WithMessage("deve ser informado.")
            .NotEqual("string").WithMessage("inválido.");
        
        RuleFor(x => x.Sobrenome)
            .NotNull().WithMessage("faltando.")
            .NotEmpty().WithMessage("deve ser informado.")
            .NotEqual("string").WithMessage("inválido.");
        
        RuleFor(x => x.Login)
            .NotNull().WithMessage("faltando.")
            .NotEmpty().WithMessage("deve ser informado.")
            .NotEqual("string").WithMessage("inválido.")
            .EmailAddress().WithMessage("Email Inválido");

        RuleFor(x => x.Senha)
            .NotNull().WithMessage("faltando.")
            .NotEmpty().WithMessage("deve ser informado.")
            .NotEqual("string").WithMessage("inválido.")
            .MaximumLength(51).WithMessage("máximo permitido de 51 caracteres");
    }
}
