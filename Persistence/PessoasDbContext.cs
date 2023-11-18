using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;
using System.Reflection.Metadata;

namespace ProjetoTesteLar.Persistence
{
    public class PessoasDbContext : IEntityTypeConfiguration<PessoaDTO>
    {
        void IEntityTypeConfiguration<PessoaDTO>.Configure(EntityTypeBuilder<PessoaDTO> builder)
        {
            
        }
    }
}
