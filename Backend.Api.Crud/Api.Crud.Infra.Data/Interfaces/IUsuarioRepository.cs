using Api.Crud.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Interfaces;

public interface IUsuarioRepository
{
    Task AddAsync(Usuario newUsuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task DeleteAsync(Usuario usuario);
    Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> condicao);
    Task<ViewUsuario> GetViewAsync(long id);
    Task<IEnumerable<ViewUsuario>> GetViewAllAsync(int skip, int take);
}
