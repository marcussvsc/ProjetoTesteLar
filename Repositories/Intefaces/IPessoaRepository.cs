using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface IPessoaRepository
    {
        public List<Pessoa> GetAllPessoas();
        public Pessoa GetPessoaByCpf(string cpf);
        public bool PostPessoa(Pessoa pessoa);
        public bool PutPessoa(Pessoa pessoa, string cpf);
        public bool DeletePessoa(string cpf);

    }
}
