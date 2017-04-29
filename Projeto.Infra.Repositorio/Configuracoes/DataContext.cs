using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Configuration;
using Projeto.Infra.Repositorio.Mapeamentos;
using System.Data.Entity.ModelConfiguration.Conventions;
using Projeto.Entidades;

namespace Projeto.Infra.Repositorio.Configuracoes
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConfigurationManager.ConnectionStrings["gerencia"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Remover o padrão de delete cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Remover padrão de pluralizar nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Adicionar classes de mapeamento
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new ProjetoMap());
            modelBuilder.Configurations.Add(new TarefaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ParticipacaoMap());
        }

        //Declarar um DbSet para cada entidade
        public DbSet<Area> Area { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Projeto.Entidades.Projeto> Projeto { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Participacao> Participacao { get; set; }
    }
}
