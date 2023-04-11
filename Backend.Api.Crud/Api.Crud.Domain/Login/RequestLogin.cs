using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Domain.Login;

public class RequestLogin
{
    public string Login { get; set; }
    public string Senha { get; set; }
}
