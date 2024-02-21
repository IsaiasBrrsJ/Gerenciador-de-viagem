using GerenciadorDeViagem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Configurations
{
    public class ViagemConfigurations : IEntityTypeConfiguration<Viagem>
    {
      
        private readonly string MatriculaUserSistemico = default!;
        public ViagemConfigurations(IConfiguration configuration)
         =>   MatriculaUserSistemico = configuration["UsuarioSistemico:Matricula"]!;
       
        public void Configure(EntityTypeBuilder<Viagem> builder)
        {
          

            builder
                  .HasKey(x => x.Id) ;

            builder
                    .HasOne(x => x.UsuarioSolicitante)
                    .WithMany(x => x.ViagensSolicitadas)
                    .HasForeignKey(x => x.UsuarioSolicitanteMatricula)
                    .HasPrincipalKey(x => x.Matricula)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

            builder.HasOne(x => x.UsuarioAprovador)
                .WithMany(x => x.ViagensAprovadas)
                .HasForeignKey(x => x.UsuarioAprovadorMatricula)
                .HasPrincipalKey(x => x.Matricula)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();


            builder
                .ToTable(cn => cn.HasCheckConstraint("const", "UsuarioSolicitanteMatricula != UsuarioAprovadorMatricula AND "+ "UsuarioAprovadorMatricula !="+ MatriculaUserSistemico));

            builder
                .ToTable("Viagem");

            builder
                .Property(x => x.DataAprovacao)
                .IsRequired(false);

            builder
                .Property(x => x.UsuarioAprovadorMatricula)
                .HasColumnType("BIGINT");

            builder
                .Property(x => x.UsuarioSolicitanteMatricula)
                .HasColumnType("BIGINT");

            builder
                .Property(x => x.Destino)
                .IsRequired();

            builder
                .Property(x => x.TipoTransporte)
                .IsRequired();
        }
    }
}
