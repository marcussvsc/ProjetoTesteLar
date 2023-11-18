using Microsoft.EntityFrameworkCore;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Persistence
{
    public class TesteLarDbContext : DbContext
    {
        public TesteLarDbContext(DbContextOptions<TesteLarDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<PessoaDTO> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Pessoa
            modelBuilder.Entity<PessoaDTO>().HasKey(p => p.PessoaId);
            modelBuilder.Entity<PessoaDTO>().HasMany(e => e.Telefones)
                .WithOne(e => e.Pessoa)
                .HasForeignKey(e => e.TelefoneId)
                .IsRequired();
            modelBuilder.Entity<PessoaDTO>().HasMany(e => e.Enderecos)
                .WithMany(e => e.Pessoas);
            //modelBuilder.Entity<Pessoa>()
            //   .HasMany(e => e.Enderecos)
            //   .WithMany(e => e.Pessoas)
            //   .UsingEntity<PessoaEndereco>(
            //       l => l.HasOne<Endereco>().WithMany().HasForeignKey(e => e.EnderecoId),
            //       r => r.HasOne<Pessoa>().WithMany().HasForeignKey(e => e.PessoaId));


            //Telefone
            modelBuilder.Entity<Telefone>().HasKey(t => t.TelefoneId);
            modelBuilder.Entity<Telefone>().HasOne(t => t.Pessoa);


            //Endereco
            modelBuilder.Entity<Endereco>().HasKey(p => p.EnderecoId);
            modelBuilder.Entity<Endereco>().HasMany(e => e.Pessoas)
                .WithMany(e => e.Enderecos);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
