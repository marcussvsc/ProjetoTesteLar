using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface ITelefoneRepository
    {
        public List<Telefone> GetAllTelefones();
        public Pessoa GetTelefoneByNumero(string telefone);
        public bool PostTelefone(Telefone telefone);
        public bool PostTelefone(Telefone telefone, string telefoneStr);
        public bool DeleteTelefone(string telefone);
    }
}
