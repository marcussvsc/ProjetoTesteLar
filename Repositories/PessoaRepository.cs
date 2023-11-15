using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoasDbContext _context;
        public PessoaRepository(PessoasDbContext context)
        {
            _context = context;
        }
        public List<Pessoa> GetAllPessoas()
        {
            List<Pessoa> pessoas = _context.Pessoas;
            return pessoas;
        }
        public Pessoa GetPessoaByCpf(string cpf)
        {
            return _context.Pessoas.SingleOrDefault(p => p.CPF.Equals(cpf));
        }
        public bool PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            return true;
        }

        public bool PutPessoa(Pessoa pessoa, string cpf)
        {
            Pessoa pessoaExistente = _context.Pessoas.SingleOrDefault(p => p.CPF.Equals(cpf));

            if (pessoaExistente != null)
            {
                pessoaExistente.Update(pessoa.Nome, pessoa.CPF, pessoa.DtNascimento, pessoa.Ativo);
                return true;
            }
            else throw new Exception("Nenhuma Pessoa encontrada com o CPF informado"); 
        }
        public bool DeletePessoa(string cpf)
        {
            Pessoa pessoa = _context.Pessoas.SingleOrDefault(p => p.CPF.Equals(cpf));

            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                return true;
            }
            else throw new Exception("Nenhuma Pessoa encontrada com o CPF informado");
            
        }

        

        

        
    }
}
