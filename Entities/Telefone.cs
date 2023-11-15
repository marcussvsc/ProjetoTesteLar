using ProjetoTesteLar.Enums;

namespace ProjetoTesteLar.DTOs
{
    public class Telefone
    {
        public string Numero { get; set; } = string.Empty;
        public TipoTelefone Tipo { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa{ get; set; }
    }
}
