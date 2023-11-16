﻿using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoasDbContext _context;
        private readonly TelefoneRepository telefoneRepository;
        public PessoaRepository(PessoasDbContext context)
        {
            _context = context;
        }
        public List<Pessoa> GetAllPessoas()
        {
            List<Pessoa> pessoas = _context.Pessoas;
            return pessoas;
        }
        public PessoaDTO GetPessoaById(int pessoaId)
        {
            Pessoa pessoa = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));

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
        public bool PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            return true;
        }

        public bool PutPessoa(Pessoa pessoa, int pessoaId)
        {
            Pessoa pessoaExistente = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));

            if (pessoaExistente != null)
            {
                pessoaExistente.Update(pessoa.Nome, pessoa.CPF, pessoa.DtNascimento, pessoa.Ativo);
                return true;
            }
            else throw new Exception("Nenhuma Pessoa encontrada com o CPF informado"); 
        }
        public bool DeletePessoa(int pessoaId)
        {
            Pessoa pessoa = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));

            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                return true;
            }
            else throw new Exception("Nenhuma Pessoa encontrada com o CPF informado");
            
        }
        private void PreencherPessoaTelefones(int pessoaId)
        {
            Pessoa pessoa = _context.Pessoas.SingleOrDefault(p => p.PessoaId.Equals(pessoaId));
            pessoa.Telefones = telefoneRepository.GetAllTelefonesPessoa(pessoaId);
        }

    }
}
