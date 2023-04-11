using Api.Crud.Domain.Result.Service;
using Api.Crud.Domain.Usuario.Create;

namespace Api.Crud.Business.Interfaces;

public interface IUsuarioService
{
    Task<ServiceResult> AddAsync(UsuarioCreate dados);
    Task<ServiceResult> GetViewAllAsync(int skip, int take);
}
