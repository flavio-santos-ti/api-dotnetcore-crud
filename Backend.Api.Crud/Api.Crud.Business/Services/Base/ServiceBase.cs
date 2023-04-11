using Api.Crud.Domain.Result;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Crud.Business.Services.Base;

public class ServiceBase
{

    protected object SuccessedAdd(object dados, string name) 
    {
        var result = new ResultSuccessed();
        result.Successed = true;
        result.Name = name;
        result.Message = name + " adicionado com sucesso.";
        result.Data = dados;
        return result;
    }

    protected object ErrorValidationAdd(ValidationResult result, string name)
    {
        var erros = new List<ResultValidationItemError>();

        foreach (var error in result.Errors)
        {
            erros.Add(
                new ResultValidationItemError
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                }
            );
        };

        var substantivo = name;

        string artigoIndefinido = substantivo.Substring(substantivo.Length - 1, 1) == "o" ? "um" : "uma";  

        ResultValidationError resultError = new();
        resultError.Name = name;
        resultError.Message = $"Erro ao tentar adicionar {artigoIndefinido} " + name + ".";
        resultError.Errors = erros;
        
        return resultError;
    }

    protected ServiceResult SuccessedViewAll(object dados, string name, int count)
    {
        string message = $"{count} registro(s) encontrado(s).";
        var result = new ServiceResult();
        result.Successed = true;
        result.Name = name;
        result.Message = message;
        result.Data = dados; 
        return result;
    }

    protected object ErrorAdd(string message, string name)
    {
        var result = new ServiceResult();
        result.Name = name;
        result.Message = message;

        return result;
    }

}
