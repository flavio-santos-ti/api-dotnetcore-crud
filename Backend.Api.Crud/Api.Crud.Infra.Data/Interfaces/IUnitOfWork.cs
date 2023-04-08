using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Interfaces;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
    Task RolbackAsync();
}
