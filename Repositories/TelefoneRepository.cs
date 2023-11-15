﻿using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly TelefonesDbContext _context;
        public TelefoneRepository(TelefonesDbContext context)
        {
            _context = context;
        }
        public List<Telefone> GetAllTelefones()
        {
            List<Telefone> telefones = _context.Telefones;
            return telefones;
        }       

        public Telefone GetTelefoneByNumero(string numero)
        {
            return _context.Telefones.SingleOrDefault(p => p.Numero.Equals(numero));
        }

        public bool PostTelefone(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            return true;
        }

        public bool PutTelefone(Telefone telefone, string numero)
        {
            Telefone telefoneExistente = _context.Telefones.SingleOrDefault(p => p.Numero.Equals(numero));

            if (telefoneExistente != null)
            {
                telefoneExistente.Update(numero, telefone.Tipo);
                return true;
            }
            else throw new Exception("Nenhum Telefone encontrado com o número informado");
        }
        public bool DeleteTelefone(string numero)
        {
            Telefone telefone = _context.Telefones.SingleOrDefault(p => p.Numero.Equals(numero));

            if (telefone != null)
            {
                _context.Telefones.Remove(telefone);
                return true;
            }
            else throw new Exception("Nenhum Telefone encontrado com o número informado");
        }
        public List<Telefone> GetAllTelefonesPessoa(int pessoaId)
        {
            List<Telefone> telefones = _context.Telefones;
            return telefones.FindAll(p => p.PessoaId.Equals(pessoaId));
        }
    }
}
