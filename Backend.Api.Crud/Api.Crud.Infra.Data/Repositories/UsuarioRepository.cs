using Api.Crud.Domain.Entities;
using Api.Crud.Infra.Data.Context;
using Api.Crud.Infra.Data.Interfaces;
using Api.Crud.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Repositories;

public class UsuarioRepository : RepositoryBase 
{
    public UsuarioRepository(DatabaseContext context) : base(context) {}

    public async Task<Usuario> AAddAsync(Usuario newUsuario) => await base.AddAsync<Usuario>(newUsuario);

    public async Task<Usuario> UpdateAsync(Usuario usuario) => await base.UpdateAsync<Usuario>(usuario);

    public async Task DeleteAsync(Usuario usuario) => await base.DeleteAsync<Usuario>(usuario);

    public async Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> condicao) => await base.GetAsync<Usuario>(condicao);
}
