using Api.Crud.Domain.Result.Service;
using Api.Crud.Domain.Usuario;

namespace Api.Crud.Business.Interfaces;

public interface IUsuarioService
{
    Task<ServiceResult> AddAsync(CreateUsuario dados);
    Task<ServiceResult> UpdateAsync(UpdateUsuario dados);
    Task<ServiceResult> DeleteAsync(long id);
    Task<ServiceResult> GetViewAllAsync(int skip, int take);
}
