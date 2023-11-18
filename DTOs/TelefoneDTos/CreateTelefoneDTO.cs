using ProjetoTesteLar.Enums;

namespace ProjetoTesteLar.DTOs.TelefoneDTos
{
    public class CreateTelefoneDTO
    {
        public string Numero { get; set; } = string.Empty;
        public TipoTelefone Tipo { get; set; }
        public int PessoaId { get; set; }
    }
}
