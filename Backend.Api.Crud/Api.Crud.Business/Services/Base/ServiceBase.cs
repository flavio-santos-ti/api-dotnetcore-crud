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

    public Result<T> Successed<T>(T dados) where T : class
    {
        var result = new Result<T>();
        result.Successed = true;
        result.Message = dados.GetType().Name;
        result.Data = dados;
        return result;
    }

}
