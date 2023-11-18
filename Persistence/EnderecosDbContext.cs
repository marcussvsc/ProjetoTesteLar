using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Persistence
{
    public class EnderecosDbContext : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            //Endereco
            builder.HasKey(p => p.EnderecoId);
            builder.HasMany(e => e.Pessoas)
                   .WithMany(e => e.Enderecos);
        }
    }
}
