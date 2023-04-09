using Api.Crud.Business.Interfaces;
using Api.Crud.Domain.Create;
using Microsoft.AspNetCore.Mvc;

namespace Api.Crud.App.Controllers.V1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> IncluirAsync(UsuarioCreate dados)
    {
        var pessoa = await _service.AddAsync(dados);

        return Ok(pessoa);
    }

}
