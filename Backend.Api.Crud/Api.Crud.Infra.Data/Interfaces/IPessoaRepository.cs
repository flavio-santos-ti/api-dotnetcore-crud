using Api.Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Interfaces;

public interface IPessoaRepository
{
    Task<Pessoa> AAddAsync(Pessoa newPessoa);
    Task<Pessoa> UpdateAsync(Pessoa pessoa);
    Task DeleteAsync(Pessoa pessoa);
    Task<Pessoa> GetAsync(Expression<Func<Pessoa, bool>> condicao);
}
