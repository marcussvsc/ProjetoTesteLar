using Microsoft.EntityFrameworkCore;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly TesteLarDbContext _context;
        public EnderecoRepository(TesteLarDbContext contex)
        {
            _context = contex;
        }       

        public List<Endereco> GetAllEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            return enderecos;
        }

        public Endereco GetEnderecoById(int enderecoId)
        {
            return _context.Enderecos.SingleOrDefault(p => p.EnderecoId.Equals(enderecoId));
        }
            
        public bool PostEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return true;
        }

        public bool PutEndereco(Endereco endereco, int enderecoId)
        {
            Endereco enderecoExistente = _context.Enderecos.SingleOrDefault(p => p.EnderecoId.Equals(enderecoId));

            if (enderecoExistente != null)
            {
                enderecoExistente.Update(endereco.CEP, endereco.Rua, endereco.Bairro, endereco.Numero,endereco.Cidade, endereco.Estado);
                _context.Update(enderecoExistente);
                _context.SaveChanges();
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
                _context.SaveChanges();
                return true;
            }
            else throw new Exception("Nenhum Endereço encontrado com o número informado");
        }
    }
}
