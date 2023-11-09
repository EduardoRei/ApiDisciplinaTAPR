using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TAPR_Disciplina.Models {
    public class RepositoryDbContext : DbContext {
        public DbSet<Disciplina> Carros { get; set; }
        private IConfiguration _configuration;
        public RepositoryDbContext(IConfiguration configuration) {
            _configuration = configuration;
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseCosmos(
                accountEndpoint: _configuration["CosmosDBURL"],
                tokenCredential: new DefaultAzureCredential(),
                databaseName: _configuration["CosmosDBDBName"],
                options => { options.ConnectionMode(ConnectionMode.Gateway); });
        }
        */
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Disciplina>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Disciplina>()
                .ToContainer("disciplina");
            modelBuilder.Entity<Disciplina>()
                .Property(p => p.id)
                .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Disciplina>()
                .HasPartitionKey(o => o.placa);
        }
        */
    }
}
