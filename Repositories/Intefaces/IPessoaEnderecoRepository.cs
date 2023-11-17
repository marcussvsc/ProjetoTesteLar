using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface IPessoaEnderecoRepository
    {
        public PessoaEndereco GetPessoaEnderecoByIds(int pessoaId, int enderecoId);
        public List<PessoaEndereco> GetPessoaEnderecosByPessoaId(int pessoaId);
        public bool PostPessoaEndereco(int pessoaId, int enderecoId);
        public bool DeletePessoaEndereco(int pessoaId, int enderecoId);
    }
}
