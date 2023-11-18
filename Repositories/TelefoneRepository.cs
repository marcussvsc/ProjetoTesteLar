using Microsoft.EntityFrameworkCore;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly TesteLarDbContext _context;
        public TelefoneRepository(TesteLarDbContext context)
        {
            _context = context;
        }
        public List<Telefone> GetAllTelefones()
        {
            List<Telefone> telefones = _context.Telefones.ToList();
            return telefones;
        }       

        public Telefone GetTelefoneByNumero(string numero)
        {
            return _context.Telefones.SingleOrDefault(p => p.Numero.Equals(numero));
        }

        public async Task<bool> PostTelefone(Telefone telefone)
        {
            await _context.Telefones.AddAsync(telefone);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool PutTelefone(Telefone telefone, string numero)
        {
            Telefone telefoneExistente = _context.Telefones.SingleOrDefault(p => p.Numero.Equals(numero));

            if (telefoneExistente != null)
            {
                //telefoneExistente.Update(numero, telefone.Tipo);
                _context.Update(telefoneExistente);
                _context.SaveChanges();
                return true;
            }
            else throw new Exception("Nenhum Telefone encontrado com o número informado");
        }
        public bool DeleteTelefone(int telefoneId)
        {
            Telefone telefone = _context.Telefones.SingleOrDefault(p => p.TelefoneId.Equals(telefoneId));

            if (telefone != null)
            {
                _context.Telefones.Remove(telefone);
                _context.SaveChanges();
                //Pessoa pessoa = pessoaContext.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(telefone.PessoaId));
                //if (pessoa != null)
                //{
                //    Telefone telefoneExistente = pessoa.Telefones.SingleOrDefault(t => t.Numero.Equals(telefone.Numero));
                //    if (telefoneExistente != null)
                //    {
                //        pessoa.Telefones.Remove(telefoneExistente);
                //    }
                //}
                return true;
            }
            else throw new Exception("Nenhum Telefone encontrado com o número informado");
        }
        public List<Telefone> GetAllTelefonesPessoa(int pessoaId)
        {
            List<Telefone> telefones = _context.Telefones.ToList();
            return telefones.FindAll(p => p.PessoaId.Equals(pessoaId));
        }        
    }
}
