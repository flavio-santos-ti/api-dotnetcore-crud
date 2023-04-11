using Api.Crud.Domain.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Validator.Usuario;

public class UpdateUsuarioValidator : AbstractValidator<UpdateUsuario>
{
    public UpdateUsuarioValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Faltando.")
            .NotEmpty().WithMessage("Deve ser informado.")
            .NotEqual(0).WithMessage("Valor Inválido");

        RuleFor(x => x.Nome)
            .NotNull().WithMessage("Faltando.")
            .NotEmpty().WithMessage("Deve ser informado.")
            .NotEqual("string").WithMessage("Conteúdo Inválido.");

        RuleFor(x => x.Sobrenome)
            .NotNull().WithMessage("faltando.")
            .NotEmpty().WithMessage("Deve ser informado.")
            .NotEqual("string").WithMessage("Conteúdo inválido.");

        RuleFor(x => x.DataNascto)
                .Must(ValidarData).WithMessage("Deve ser informado.");
    }
    private bool ValidarData(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }


}
