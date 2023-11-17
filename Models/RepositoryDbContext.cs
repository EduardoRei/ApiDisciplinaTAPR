using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace TAPR_Disciplina.Models {
    public class RepositoryDbContext : DbContext {
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Professor> Professores {get; set;}
        private IConfiguration _configuration;
        public RepositoryDbContext(IConfiguration configuration) {
            _configuration = configuration;
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseCosmos(
                accountEndpoint: _configuration["CosmosDBURL"],
                tokenCredential: new DefaultAzureCredential(),
                databaseName: _configuration["CosmosDBDBName"],
                options => { options.ConnectionMode(ConnectionMode.Gateway); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Curso>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Curso>()
                .ToContainer("curso");
            modelBuilder.Entity<Curso>()
                .Property(p => p.idCurso)
                .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Curso>()
                .HasPartitionKey(o => o.idCurso);
            modelBuilder.Entity<Curso>()
                .HasKey(c => c.idCurso);
        
            modelBuilder.Entity<Professor>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Professor>()
                .ToContainer("professor");
            modelBuilder.Entity<Professor>()
                .Property(p => p.idProfessor)
                .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Professor>()
                .HasPartitionKey(o => o.idProfessor);
            modelBuilder.Entity<Professor>()
                .HasKey(c => c.idProfessor);

            modelBuilder.Entity<Disciplina>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Disciplina>()
                .ToContainer("disciplina");
            modelBuilder.Entity<Disciplina>()
                .Property(p => p.idDisciplina)
                .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Disciplina>()
                .HasPartitionKey(o => o.idDisciplina);
            modelBuilder.Entity<Disciplina>()
                .HasKey(c => c.idDisciplina);
            modelBuilder.Entity<Disciplina>()
                .HasOne<Curso>(o => o.curso);
        }
    
    }
}
