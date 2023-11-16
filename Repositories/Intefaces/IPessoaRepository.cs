using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface IPessoaRepository
    {
        public List<Pessoa> GetAllPessoas();
        public PessoaDTO GetPessoaById(int pessoaId);
        public bool PostPessoa(Pessoa pessoa);
        public bool PutPessoa(Pessoa pessoa, int pessoaId);
        public bool DeletePessoa(int pessoaId);

    }
}
