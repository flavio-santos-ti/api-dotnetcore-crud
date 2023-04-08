using Api.Crud.Domain.Entities;
using Api.Crud.Infra.Data.Context;
using Api.Crud.Infra.Data.Interfaces;
using Api.Crud.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Repositories;

public class UsuarioRepository : RepositoryBase 
{
    public UsuarioRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<Usuario> AAddAsync(Usuario newUsuario)
    {
        return await base.AddAsync<Usuario>(newUsuario);
    }

}
