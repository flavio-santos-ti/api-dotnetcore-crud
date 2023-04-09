using Api.Crud.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Entities;

public class Pessoa : EntityBase 
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascto { get; set; }
    public string Tipo { get; set; } 
    public int Referencia { get; set; }
}
