using Api.Crud.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Entities;

public class Usuario : Pessoa
{
    public string Login { get; set; }
    public string Senha { get; set; }
}
