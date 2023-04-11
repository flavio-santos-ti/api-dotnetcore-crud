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
    public async Task<IActionResult> AddAsync(UsuarioCreate dados)
    {
        var usuario = await _service.AddAsync(dados);
        
        return (!usuario.Successed) ? BadRequest(usuario) : Ok(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> GetViewAllAsync([FromQuery] int skip, [FromQuery] int take)
    {
        var usuario = await _service.GetViewAllAsync(skip, take);
        
        if (!usuario.Successed)
        {
            return BadRequest(usuario);
        }
        
        return Ok(usuario);
    }

}
