using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Usuario;

public class UpdateUsuario
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascto { get; set; }
}
