using Api.Crud.Domain.Login;
using Api.Crud.Domain.Result.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Interfaces;

public interface ILoginService
{
    Task<ServiceResult> RequestAuthorizationAsync(RequestLogin dados);
}
