using Api.Crud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Crud.Infra.Data.Mappings;

public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Nome).HasColumnName("nome");
        builder.Property(x => x.Sobrenome).HasColumnName("sobrenome");
        builder.Property(x => x.DataNascto).HasColumnName("dt_nascto");
        builder.Property(x => x.Tipo).HasColumnName("tipo");
        builder.Property(x => x.Referencia).HasColumnName("referencia");
        builder.Property(x => x.DataInclusao).HasColumnName("dt_inclusao");
        builder.Property(x => x.DataAlteracao).HasColumnName("dt_alteracao");
    }
}
