using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Entities;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class PessoaEnderecoRepository : IPessoaEnderecoRepository
    {
        private readonly PessoaEnderecoDbContext _context;
        private readonly PessoasDbContext _pessoaContext;
        private readonly EnderecosDbContext _enderecoContext;
        public PessoaEnderecoRepository(PessoaEnderecoDbContext contex, PessoasDbContext pessoaContext, EnderecosDbContext enderecoContext)
        {
            _context = contex;
            _pessoaContext = pessoaContext;
            _enderecoContext = enderecoContext;
        }       

        public PessoaEndereco GetPessoaEnderecoByIds(int pessoaId, int enderecoId)
        {
            return _context.PessoasEnderecos.SingleOrDefault(p =>  p.PessoaId.Equals(pessoaId) && p.EnderecoId.Equals(enderecoId));
        }

        public bool PostPessoaEndereco(int pessoaId, int enderecoId)
        {
            PessoaRepository pessoaRepository = new PessoaRepository(_pessoaContext);
            EnderecoRepository enderecoRepository = new EnderecoRepository(_enderecoContext);
            PessoaDTO pessoa = pessoaRepository.GetPessoaById(pessoaId);
            if(pessoa == null)
                throw new Exception("Nenhuma Pessoa encontrada com o ID informado");
            Endereco endereco = enderecoRepository.GetEnderecoById(enderecoId);
            if(endereco == null)
                throw new Exception("Nenhum Endereço encontrado com o ID informado");

            _context.PessoasEnderecos.Add(new PessoaEndereco() { PessoaId = pessoaId, EnderecoId = enderecoId});
            return true;
        }
        public bool DeletePessoaEndereco(int pessoaId, int enderecoId)
        {
            PessoaEndereco pessoaEndereco = GetPessoaEnderecoByIds(pessoaId, enderecoId);
            if (pessoaEndereco == null)
                throw new Exception("Nenhum Endereço encontrado com o número informado");          
            _context.PessoasEnderecos.Remove(pessoaEndereco);
            return true;
        }
    }
}
