using GerenciadorDeViagem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
              .HasKey(pk => pk.Id);


            builder
                .HasMany(X => X.ViagensSolicitadas)
                .WithOne(x => x.UsuarioSolicitante)
                .HasForeignKey(x => x.UsuarioSolicitanteMatricula)
                .HasPrincipalKey(x => x.Matricula)
                .OnDelete(DeleteBehavior.NoAction);


            builder
                .HasMany(X => X.ViagensAprovadas)
                .WithOne(x => x.UsuarioAprovador)
                .HasForeignKey(x => x.UsuarioAprovadorMatricula)
                .HasPrincipalKey(x => x.Matricula)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Matricula)
                .IsRequired()
                .HasColumnType("BIGINT");
                

            builder
                .Property(x => x.Senha)
                .IsRequired()
               .HasColumnType("NVarChar(max)");

            builder
                .Property(x => x.TipoDeUsuario)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("tinyint");


            builder
              .Property(x => x.Email)
              .IsRequired()
              .HasColumnType("varchar(45)");

            builder
                .Property(x => x.Ativo)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("tinyint");
            builder
              .Property(x => x.NomeCompleto)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder
                .ToTable("Usuario");
        }
    }
}
