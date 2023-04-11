﻿using Api.Crud.Domain.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Validator.Usuario;

public class ValidatorUsuarioUpdate : AbstractValidator<UpdateUsuario>
{
    public ValidatorUsuarioUpdate()
    {
        RuleFor(x => x.Nome)
            .NotNull().WithMessage("Faltando.")
            .NotEmpty().WithMessage("Deve ser informado.")
            .NotEqual("string").WithMessage("inválido.");

        RuleFor(x => x.Sobrenome)
            .NotNull().WithMessage("faltando.")
            .NotEmpty().WithMessage("Deve ser informado.")
            .NotEqual("string").WithMessage("inválido.");

        RuleFor(x => x.DataNascto)
                .Must(ValidarData).WithMessage("Deve ser informado.");
    }
    private bool ValidarData(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }


}
