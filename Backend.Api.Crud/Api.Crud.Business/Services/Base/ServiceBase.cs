using Api.Crud.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Services.Base;

public class ServiceBase
{
    public ServiceBase()
    {
    }

    public Result<T> SuccessedAdd<T>(T dados, string name) where T : class
    {
        var result = new Result<T>();
        result.Successed = true;
        result.Name = name;
        result.Message = name + " adicionado com sucesso.";
        result.Data = dados;
        return result;
    }

}
