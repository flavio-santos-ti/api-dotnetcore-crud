using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Usuario.Create;

public class UsuarioCreate
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascto { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}
