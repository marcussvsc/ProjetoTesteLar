using Microsoft.EntityFrameworkCore;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly EnderecosDbContext _context;
        public EnderecoRepository(EnderecosDbContext contex)
        {
            _context = contex;
        }       

        public List<Endereco> GetAllEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos;
            return enderecos;
        }

        public Endereco GetEnderecoById(int enderecoId)
        {
            return _context.Enderecos.SingleOrDefault(p => p.EnderecoId.Equals(enderecoId));
        }
            
        public bool PostEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            return true;
        }

        public bool PutEndereco(Endereco endereco, int enderecoId)
        {
            Endereco enderecoExistente = _context.Enderecos.SingleOrDefault(p => p.EnderecoId.Equals(enderecoId));

            if (enderecoExistente != null)
            {
                enderecoExistente.Update(endereco.CEP, endereco.Rua, endereco.Bairro, endereco.Numero,endereco.Cidade, endereco.Estado);
                return true;
            }
            else throw new Exception("Nenhum Endereço encontrado com o número informado");
        }
        public bool DeleteEndereco(int enderecoId)
        {
            Endereco endereco = _context.Enderecos.SingleOrDefault(p => p.EnderecoId.Equals(enderecoId));

            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                return true;
            }
            else throw new Exception("Nenhum Endereço encontrado com o número informado");
        }
    }
}
