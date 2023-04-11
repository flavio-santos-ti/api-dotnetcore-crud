using Api.Crud.Business.Interfaces;
using Api.Crud.Domain.Login;
using Api.Crud.Domain.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Api.Crud.App.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _service;

    public LoginController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(RequestLogin dados)
    {
        var usuario = await _service.RequestAuthorizationAsync(dados);

        return (!usuario.Successed) ? BadRequest(usuario) : Ok(usuario);
    }



}
