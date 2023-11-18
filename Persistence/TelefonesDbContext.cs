using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using ProjetoTesteLar.DTOs;
using System.Reflection.Emit;

namespace ProjetoTesteLar.Persistence
{
    public class TelefonesDbContext : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            
        }
    }
}
