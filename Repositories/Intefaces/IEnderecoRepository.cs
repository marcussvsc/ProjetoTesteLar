using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.Repositories.Intefaces
{
    public interface IEnderecoRepository
    {
        public List<Endereco> GetAllEnderecos();
        public Endereco GetEnderecoById(int enderecoId);
        public bool PostEndereco(Endereco endereco);
        public bool PutEndereco(Endereco endereco, int enderecoId);
        public bool DeleteEndereco(int enderecoId);
    }
}
