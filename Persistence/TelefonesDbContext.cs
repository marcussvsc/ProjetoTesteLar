using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Persistence
{
    public class TelefonesDbContext
    {
        public TelefonesDbContext() 
        {
            Telefones = new List<Telefone>();
        }
        public List<Telefone> Telefones { get; set; }
    }
}
