using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Persistence
{
    public class PessoaEnderecosDbContext
    {
        public PessoaEnderecosDbContext()
        {
            PessoasEnderecos = new List<PessoaEndereco>();
        }
        public List<PessoaEndereco> PessoasEnderecos { get; set; }
    }
}
