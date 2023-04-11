using Api.Crud.Business.Interfaces;
using Api.Crud.Domain.Pessoa;
using Api.Crud.Infra.Data.Interfaces;
using Api.Crud.Infra.Data.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(Pessoa dados)
    {
        dados.Referencia += 1;
        dados.DataInclusao = DateTime.Now;
        dados.DataAlteracao = DateTime.Now;
        await _pessoaRepository.AddAsync(dados);
        await _unitOfWork.SaveAsync();
    }

    public async Task<Pessoa> GetAsync(Expression<Func<Pessoa, bool>> condicao) => await _pessoaRepository.GetAsync(condicao);
}
