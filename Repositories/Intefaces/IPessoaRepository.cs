using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface IPessoaRepository
    {
        public List<PessoaDTO> GetAllPessoas();
        public Task<PessoaDTO> GetPessoaById(int pessoaId);
        public bool PostPessoa(PessoaDTO pessoa);
        public bool PutPessoa(PessoaDTO pessoa, int pessoaId);
        public bool DeletePessoa(int pessoaId);

    }
}
