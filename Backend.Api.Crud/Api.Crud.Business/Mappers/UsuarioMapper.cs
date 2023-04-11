using Api.Crud.Domain.Pessoa;
using Api.Crud.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Business.Mappers;

public class UsuarioMapper : AutoMapper.Profile
{
    public UsuarioMapper()
    {
        CreateMap<Usuario, CreateUsuario>().ReverseMap();
        CreateMap<Usuario, ViewUsuario>().ReverseMap();
        CreateMap<Pessoa, CreateUsuario>().ReverseMap();
    }
}
