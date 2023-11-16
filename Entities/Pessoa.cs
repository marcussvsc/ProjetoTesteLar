using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.DTOs
{
    public class Pessoa
    {        
        public int PessoaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public List<Telefone>? Telefones { get; set; }
        public List<Endereco>? Enderecos { get; set; }

        public void Update(string nome, string cpf, DateTime dtNascimento, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            DtNascimento = dtNascimento;
            Ativo = ativo;
        }
    }
}
