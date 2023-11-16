namespace ProjetoTesteLar.Entities
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public void Update(string cep, string rua, string bairro, string cidade, string estado)
        {
            CEP = cep;
            Rua = rua; 
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
