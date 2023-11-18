using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public List<PessoaDTO>? Pessoas { get; set; }

        public void Update(string cep, string rua, string bairro, int numero, string cidade, string estado)
        {
            CEP = cep;
            Rua = rua; 
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
