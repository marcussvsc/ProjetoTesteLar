using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Persistence
{
    public class EnderecosDbContext : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            
        }
    }
}
