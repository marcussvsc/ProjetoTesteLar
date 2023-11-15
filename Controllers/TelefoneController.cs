using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Telefone>> GetAllTelefones() 
        {
            return Ok();
        }
        [HttpGet("{telefone}")]
        public ActionResult<Pessoa> GetTelefoneByNumero(string telefone)
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult<bool> PostTelefone(Telefone telefone)
        {
            return Ok();    
        }
        [HttpPut]
        public ActionResult<bool> PostTelefone(Telefone telefone, string telefoneStr)
        {
            return Ok();
        }
        [HttpDelete("{telefone}")]
        public ActionResult<bool> DeleteTelefone(string telefone)
        {
            return Ok();
        }
    }
}
