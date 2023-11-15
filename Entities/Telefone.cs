namespace ProjetoTesteLar.DTOs
{
    public class Telefone
    {
        public Pessoa Pessoa{ get; set; } = new PessoaDTO();
        public string Numero { get; set; } = string.Empty;

        //Tipo
    }
}
