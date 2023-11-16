using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Entities
{
    public class PessoaEndereco
    {
        public int PessoaId { get; set; }
        public int EnderecoId { get; set; }
        public Pessoa? Pessoa { get; set; } = null;
        public Endereco? Endereco { get; set; } = null;
    }
}
