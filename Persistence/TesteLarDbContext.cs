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
            modelBuilder.ApplyConfiguration(new PessoasDbContext());
            modelBuilder.ApplyConfiguration(new TelefonesDbContext());
            modelBuilder.ApplyConfiguration(new EnderecosDbContext());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
