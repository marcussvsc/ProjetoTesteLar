using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Persistence
{
    public class PessoaEnderecoDbContext
    {
        public PessoaEnderecoDbContext()
        {
            PessoasEnderecos = new List<PessoaEndereco>();
        }
        public List<PessoaEndereco> PessoasEnderecos { get; set; }
    }
}
