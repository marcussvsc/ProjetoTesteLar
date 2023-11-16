using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Persistence
{
    public class EnderecosDbContext
    {
        public EnderecosDbContext() 
        {
            Enderecos = new List<Endereco>();
        }
        public List<Endereco> Enderecos { get; set; }
    }
}
