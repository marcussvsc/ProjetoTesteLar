namespace ProjetoTesteLar.DTOs
{
    public class Pessoa
    {
        public Pessoa(string nome, string cpf, DateTime dtNascimento, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            DtNascimento = dtNascimento;
            Ativo = ativo;
        }

        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public List<Telefone> lTelefone { get; set; } = new List<Telefone>();

        public void Update(string nome, string cpf, DateTime dtNascimento, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            DtNascimento = dtNascimento;
            Ativo = ativo;
        }
    }
}
