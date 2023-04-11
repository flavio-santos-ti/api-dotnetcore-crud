using Api.Crud.Business.Interfaces;
using Api.Crud.Business.Services.Base;
using Api.Crud.Domain.Pessoa;
using Api.Crud.Domain.Result.Service;
using Api.Crud.Domain.Usuario;
using Api.Crud.Infra.Data.Interfaces;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using BC = BCrypt.Net.BCrypt;

namespace Api.Crud.Business.Services;

public class UsuarioService : ServiceBase, IUsuarioService
{
    private readonly IPessoaService _pessoaService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidator<CreateUsuario> _validatorCreate;

    public UsuarioService(IPessoaService pessoaService, IMapper mapper, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IValidator<CreateUsuario> validatorCreate)
    {
        _pessoaService = pessoaService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _validatorCreate = validatorCreate;
    }

    public async Task<ServiceResult> AddAsync(CreateUsuario dados) 
    {
        long newId = 0;

        ValidationResult result = await _validatorCreate.ValidateAsync(dados);

        if (!result.IsValid)
        {
            return base.ErrorValidationAdd(result, "Usuário"); 
        }

        await _unitOfWork.BeginTransactionAsync();

        var pessoa = await _pessoaService.GetAsync(b => b.Nome == dados.Nome && b.Sobrenome == dados.Sobrenome);

        if (pessoa == null)
        {
            Pessoa newPessoa = _mapper.Map<Pessoa>(dados);
            newPessoa.Tipo = "F";
            await _pessoaService.AddAsync(newPessoa);
            newId = newPessoa.Id;
        } else
        {
            newId = pessoa.Id;
        }
        
        var usuario = await _usuarioRepository.GetAsync(b => b.Login == dados.Login.Trim());
          
        if (usuario == null)
        {
            Usuario newUsuario = new();
            newUsuario.Id = newId;
            newUsuario.Login = dados.Login.Trim();
            newUsuario.Senha = BC.HashPassword(dados.Senha); 
            newUsuario.DataInclusao = DateTime.Now;
            newUsuario.DataAlteracao = DateTime.Now;
            await _usuarioRepository.AddAsync(newUsuario);
            await _unitOfWork.SaveAsync();
        } else
        {
            await _unitOfWork.RolbackAsync();
            return base.ErrorAdd($"O email {dados.Login.Trim()} já está sendo utilizado.", "Usuário");
        }

        await _unitOfWork.CommitAsync();

        var usuarioView = await _usuarioRepository.GetViewAsync(newId);

        return base.SuccessedAdd(usuarioView, "Usuário");
    }

    public async Task<ServiceResult> GetViewAllAsync(int skip, int take)
    {
        var usuarios = await _usuarioRepository.GetViewAllAsync(skip, take);
        
        return base.SuccessedViewAll(usuarios, "Usuário", usuarios.Count());
    }

    //public async Task<ServiceResult> UpdateAsync(UsuarioUpdate dados)
    //{
    //    ValidationResult result = await _validatorCreate.ValidateAsync(dados);

    //    if (!result.IsValid)
    //    {
    //        return base.ErrorValidationAdd(result, "Usuário");
    //    }

    //}
}
