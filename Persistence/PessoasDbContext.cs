using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Persistence
{
    public class PessoasDbContext
    {
        public PessoasDbContext() 
        {
            Pessoas = new List<Pessoa>();
        }
        public List<Pessoa > Pessoas { get; set; }
    }
}
