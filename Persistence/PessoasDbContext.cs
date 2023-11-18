using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;

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
            builder.HasMany(e => e.Enderecos)
               .WithMany(e => e.Pessoas)
               .UsingEntity<PessoaEndereco>();

        }
    }
}
