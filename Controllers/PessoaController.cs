using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pessoa>> GetAllPessoas() 
        {
            return Ok();
        }
    }
}
