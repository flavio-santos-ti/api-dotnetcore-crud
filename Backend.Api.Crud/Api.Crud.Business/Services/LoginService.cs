using Api.Crud.Business.Interfaces;
using Api.Crud.Business.Services.Base;
using Api.Crud.Domain.Login;
using Api.Crud.Domain.Result.Service;
using Api.Crud.Domain.Usuario;
using Api.Crud.Infra.Data.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace Api.Crud.Business.Services;

public class LoginService : ServiceBase, ILoginService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<RequestLogin> _validatorRequest;

    


    public LoginService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IValidator<RequestLogin> validatorRequest)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _validatorRequest = validatorRequest;
    }

    private object GetToken(Usuario dados)
    {
        string tokenSecret = _unitOfWork.GetTokenSecret();
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));

        JwtSecurityTokenHandler tokenHandler = new();
        //tokenHandler = new();


        return new TokenLogin
        {
            ExpiresAt = DateTime.UtcNow.AddHours(2),

            CreatedAt = DateTime.UtcNow,
            Hash = tokenHandler.WriteToken
            (
                tokenHandler.CreateToken
                (
                    new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                                new Claim(ClaimTypes.Name, dados.Login),
                                new Claim("UsuarioId", dados.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddHours(2),
                        SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
                    }
                )
            ),
            UsuarioId = dados.Id,
            Login = dados.Login
        };
    }

    public async Task<ServiceResult> RequestAuthorizationAsync(RequestLogin dados)
    {
        
        ValidationResult result = await _validatorRequest.ValidateAsync(dados);

        if (!result.IsValid)
        {
            return base.ErrorValidationAdd(result, "Usuário");
        }

        var usuario = await _usuarioRepository.GetAsync(b => b.Login == dados.Login.Trim());
        
        if (usuario == null)
        {
            return base.ErrorAdd($"Login ou senha inválida.", "Usuário");
        }

        if (!BC.Verify(dados.Senha, usuario.Senha))
        {
            return base.ErrorAdd($"Senha ou login inválida.", "Usuário");
        }

        var tokenLogin = this.GetToken(usuario);
        
        return base.SuccessedAdd(tokenLogin, "Usuário");
    }

}

