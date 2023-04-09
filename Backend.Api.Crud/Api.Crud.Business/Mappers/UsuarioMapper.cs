using Api.Crud.Domain.Create;
using Api.Crud.Domain.Entities;
using Api.Crud.Domain.View;
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
        CreateMap<Usuario, UsuarioCreate>().ReverseMap();
        CreateMap<Usuario, UsuarioView>().ReverseMap();
        CreateMap<Pessoa, UsuarioCreate>().ReverseMap();
    }
}
