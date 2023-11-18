using ProjetoTesteLar.Entities;

namespace ProjetoTesteLar.DTOs
{
    public class PessoaDTO
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public virtual List<Telefone>? Telefones { get; set; }
        public virtual List<Endereco>? Enderecos { get; set; }
    }
}
