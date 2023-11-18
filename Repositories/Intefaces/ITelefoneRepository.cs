using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface ITelefoneRepository
    {
        public List<Telefone> GetAllTelefones();
        public List<Telefone> GetAllTelefonesPessoa(int pessoaId);
        public Telefone GetTelefoneByNumero(string numero);
        public Task<bool> PostTelefone(Telefone telefone);
        public bool PutTelefone(Telefone telefone, string numero);
        public bool DeleteTelefone(int telefoneId);
    }
}
