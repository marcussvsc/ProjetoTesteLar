using Microsoft.EntityFrameworkCore;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly TesteLarDbContext _context;
        public PessoaRepository(TesteLarDbContext context)
        {
            _context = context;
        }

        public List<PessoaDTO> GetAllPessoas()
        {
            List<PessoaDTO> pessoas = _context.Pessoas
                                      .Include(p => p.Telefones)
                                      .ToList();
            return pessoas;
        }

        public async Task<PessoaDTO> GetPessoaById(int pessoaId)
        {
            PessoaDTO pessoa = await _context.Pessoas.AsNoTracking().SingleOrDefaultAsync(p => p.PessoaId.Equals(pessoaId));

            if (pessoa == null)
                return null;
            return new PessoaDTO() 
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Ativo = pessoa.Ativo,
                CPF = pessoa.CPF,
                DtNascimento = pessoa.DtNascimento
            };
        }

        public bool PostPessoa(PessoaDTO pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return true;
        }        

        public bool PutPessoa(PessoaDTO pessoa, int pessoaId)
        {
            PessoaDTO pessoaExistente = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));

            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.CPF = pessoa.CPF;
                pessoaExistente.DtNascimento = pessoa.DtNascimento;
                pessoaExistente.Ativo = pessoa.Ativo;
                _context.Update(pessoaExistente);
                _context.SaveChanges();
                return true;
            }
            else throw new Exception("Nenhuma Pessoa encontrada com o ID informado"); 
        }

        public bool DeletePessoa(int pessoaId)
        {
            PessoaDTO pessoa = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));

            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();
                return true;
            }
            else throw new Exception("Nenhuma Pessoa encontrada com o ID informado");
            
        }

        private void PreencherPessoaTelefones(int pessoaId)
        {
            //PessoaDTO pessoa = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));
            //pessoa.Telefones = telefoneRepository.GetAllTelefonesPessoa(pessoaId);
        }

    }
}
