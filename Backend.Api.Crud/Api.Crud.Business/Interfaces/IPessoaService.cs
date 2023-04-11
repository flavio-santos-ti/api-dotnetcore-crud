using Api.Crud.Domain.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Interfaces;

public interface IPessoaService
{
    Task AddAsync(Pessoa dados);
    Task UpdateAsync(Pessoa dados);
    Task<Pessoa> GetAsync(Expression<Func<Pessoa, bool>> condicao);
}
