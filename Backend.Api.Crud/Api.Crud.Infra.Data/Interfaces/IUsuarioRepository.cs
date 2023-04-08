using Api.Crud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario> AAddAsync(Usuario newUsuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task DeleteAsync(Usuario usuario);
    Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> condicao);
}
