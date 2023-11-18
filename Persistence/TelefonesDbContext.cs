using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Persistence
{
    public class TelefonesDbContext : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            //Telefone
            builder.HasKey(t => t.TelefoneId);
            builder.HasOne(t => t.Pessoa);
        }
    }
}
