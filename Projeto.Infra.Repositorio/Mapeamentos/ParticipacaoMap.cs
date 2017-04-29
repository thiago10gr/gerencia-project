using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using Projeto.Entidades;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Infra.Repositorio.Mapeamentos
{
    public class ParticipacaoMap : EntityTypeConfiguration<Participacao>
    {
        public ParticipacaoMap()
        {

            ToTable("tbl_participacao");


            HasKey(p => p.IdParticipacao);

            Property(p => p.IdProjeto)
                .HasColumnName("id_participacao")
                .IsRequired();


            //chave composta
            //HasKey(pa => new { pa.IdProjeto, pa.IdUsuario });


            Property(pa => pa.IdProjeto)
              .HasColumnName("id_projeto")
              .IsRequired()
              .HasColumnAnnotation(IndexAnnotation.AnnotationName, //definindo a coluna email como unica
                    new IndexAnnotation(
                        new IndexAttribute("index_participacao", 1) { IsUnique = true }));

            HasRequired(pa => pa.Projeto)
                .WithMany(po => po.Participacoes)
                .HasForeignKey(pa => pa.IdProjeto); //foreing key



            Property(pa => pa.IdUsuario)
              .HasColumnName("id_usuario")
              .IsRequired()
              .HasColumnAnnotation(IndexAnnotation.AnnotationName, //definindo a coluna email como unica
                    new IndexAnnotation(
                        new IndexAttribute("index_participacao", 2) { IsUnique = true }));


            HasRequired(pa => pa.Usuario)
                .WithMany(u => u.Participacoes)
                .HasForeignKey(pa => pa.IdUsuario); //foreing key

        }
    }
}
