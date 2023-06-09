﻿using Api.Crud.Domain.Result.Service;
using Api.Crud.Domain.Result.Service.Validation;
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

    protected ServiceResult SuccessedAdd(object dados, string name) 
    {
        var result = new ServiceResult();
        result.Successed = true;
        result.Name = name;
        result.Message = name + " adicionado com sucesso.";
        result.Data = dados;
        return result;
    }

    protected ServiceResult SuccessedUpdate(object dados, string name)
    {
        var result = new ServiceResult();
        result.Successed = true;
        result.Name = name;
        result.Message = name + " alterado com sucesso.";
        result.Data = dados;
        return result;
    }

    protected ServiceResult SuccessedDelete(string name)
    {
        var result = new ServiceResult();
        result.Successed = true;
        result.Name = name;
        result.Message = name + " excluído com sucesso.";
        result.Data = null;
        return result;
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

    protected ServiceResult ErrorValidationAdd(ValidationResult result, string name)
    {
        var erros = new List<ServiceValidationResult>();

        foreach (var error in result.Errors)
        {
            erros.Add(
                new ServiceValidationResult
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                }
            );
        };

        var substantivo = name;

        string artigoIndefinido = substantivo.Substring(substantivo.Length - 1, 1) == "o" ? "um" : "uma";  

        ServiceResult resultError = new();
        resultError.Successed = false;
        resultError.Name = name;
        resultError.Message = $"Erro ao tentar adicionar {artigoIndefinido} " + name + ".";
        resultError.Data = erros;
        
        return resultError;
    }

    protected ServiceResult ErrorValidationUpdate(ValidationResult result, string name)
    {
        var erros = new List<ServiceValidationResult>();

        foreach (var error in result.Errors)
        {
            erros.Add(
                new ServiceValidationResult
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                }
            );
        };

        var substantivo = name;

        string artigoIndefinido = substantivo.Substring(substantivo.Length - 1, 1) == "o" ? "um" : "uma";

        ServiceResult resultError = new();
        resultError.Successed = false;
        resultError.Name = name;
        resultError.Message = $"Erro ao tentar alterar {artigoIndefinido} " + name + ".";
        resultError.Data = erros;

        return resultError;
    }


    protected ServiceResult ErrorAdd(string message, string name)
    {
        var result = new ServiceResult();
        result.Name = name;
        result.Message = message;

        return result;
    }




}
