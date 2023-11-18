using ProjetoTesteLar.Enums;
using System.Text.Json.Serialization;

namespace ProjetoTesteLar.DTOs
{
    public class Telefone
    {
        public int TelefoneId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public TipoTelefone Tipo { get; set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public virtual PessoaDTO Pessoa{ get; set; }

        public void Update(string numero, TipoTelefone tipo)
        {
            Numero = numero;
            Tipo = tipo;
        }
    }
}
