using Api.Crud.Domain.Entities;
using Api.Crud.Domain.View;
using Api.Crud.Infra.Data.Context;
using Api.Crud.Infra.Data.Interfaces;
using Api.Crud.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Repositories;

public class UsuarioRepository : RepositoryBase, IUsuarioRepository 
{
    public UsuarioRepository(DatabaseContext context) : base(context) {}

    public async Task AddAsync(Usuario newUsuario) => await base.AddAsync<Usuario>(newUsuario);

    public async Task<Usuario> UpdateAsync(Usuario usuario) => await base.UpdateAsync<Usuario>(usuario);

    public async Task DeleteAsync(Usuario usuario) => await base.DeleteAsync<Usuario>(usuario);

    public async Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> condicao) => await base.GetAsync<Usuario>(condicao);

    public async Task<UsuarioView> GetViewAsync(long id)
    {
        DatabaseContext context = base.GetContext();

        var usuarioView = await (
            from usuario in context.Usuarios
            join pessoa in context.Pessoas on usuario.Id equals pessoa.Id
            where pessoa.Id == id
            select new UsuarioView
            {
                Id = usuario.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                DataNascto = pessoa.DataNascto,
                Tipo = pessoa.Tipo == "F" ? "Física" : "Jurídica",
                Login = usuario.Login,
                DataInclusao = usuario.DataInclusao,
                DataAlteracao= usuario.DataAlteracao
            }).AsNoTracking()
            .FirstOrDefaultAsync();
            
        return usuarioView;
    }

    public async Task<IEnumerable<UsuarioView>> GetViewAllAsync(int skip, int take)
    {
        DatabaseContext context = base.GetContext();

        var usuarioView = await(
            from usuario in context.Usuarios
            join pessoa in context.Pessoas on usuario.Id equals pessoa.Id
            select new UsuarioView
            {
                Id = usuario.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                DataNascto = pessoa.DataNascto,
                Tipo = pessoa.Tipo == "F" ? "Física" : "Jurídica",
                Login = usuario.Login,
                DataInclusao = usuario.DataInclusao,
                DataAlteracao = usuario.DataAlteracao
            }).AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();
         
        return usuarioView;
    }

}
