using Api.Crud.Domain.Entities;
using Api.Crud.Infra.Data.Context;
using Api.Crud.Infra.Data.Interfaces;
using Api.Crud.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Crud.Infra.Data.Repositories;

public class PessoaRepository : RepositoryBase, IPessoaRepository
{
    public PessoaRepository(DatabaseContext context) : base(context) { }

    public async Task<Pessoa> AAddAsync(Pessoa newPessoa) => await base.AddAsync<Pessoa>(newPessoa);

    public async Task<Pessoa> UpdateAsync(Pessoa pessoa) => await base.UpdateAsync<Pessoa>(pessoa);

    public async Task DeleteAsync(Pessoa pessoa) => await base.DeleteAsync<Pessoa>(pessoa);

    public async Task<Pessoa> GetAsync(Expression<Func<Pessoa, bool>> condicao) => await base.GetAsync<Pessoa>(condicao);
}
