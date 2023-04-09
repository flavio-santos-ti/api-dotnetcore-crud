﻿using Api.Crud.Domain.Create;
using Api.Crud.Domain.Entities;
using Api.Crud.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Interfaces;

public interface IUsuarioService
{
    Task<Result<Usuario>> AddAsync(UsuarioCreate dados);
}
