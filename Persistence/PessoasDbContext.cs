using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Persistence
{
    public class PessoasDbContext : IEntityTypeConfiguration<PessoaDTO>
    {
        public void Configure(EntityTypeBuilder<PessoaDTO> builder)
        {
            //Pessoa
            builder.HasKey(p => p.PessoaId);
            builder.HasMany(e => e.Telefones);  
            builder.HasMany(e => e.Enderecos)
                   .WithMany(e => e.Pessoas);
            //modelBuilder.Entity<Pessoa>()
            //   .HasMany(e => e.Enderecos)
            //   .WithMany(e => e.Pessoas)
            //   .UsingEntity<PessoaEndereco>(
            //       l => l.HasOne<Endereco>().WithMany().HasForeignKey(e => e.EnderecoId),
            //       r => r.HasOne<Pessoa>().WithMany().HasForeignKey(e => e.PessoaId));

        }
    }
}
